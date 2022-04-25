using System.ComponentModel;
using System.Runtime.InteropServices;

// https://stackoverflow.com/questions/35627212/how-to-display-the-progress-of-the-operation-at-the-taskbar-icon-in-c-sharp-wind
namespace ADBMailer.CustomControls
{
    [ToolboxBitmap(typeof(Form))]
    public class ProgressForm : Form
    {
        private ThumbnailProgressState _progressState = ThumbnailProgressState.NoProgress;
        private int _minimumProgressValue = 0;
        private int _maximumProgressValue = 100;
        private int _progressValue = 0;
        private static CRegisteredTaskbar? _registeredTaskbar = null;
        private static bool _registeredTaskbarFetched = false;

        //
        // Summary:
        //     Gets or sets the state in which progress should be indicated on the task bar.
        //
        // Returns:
        //     One of the System.Windows.Forms.ThumbnailProgressState values. The default is System.Windows.Forms.ThumbnailProgressState.NoProgress
        //
        // Exceptions:
        //   T:System.ComponentModel.InvalidEnumArgumentException:
        //     The value is not a member of the System.Windows.Forms.ThumbnailProgressState enumeration.
        [Browsable(true)]
        [DefaultValue(ThumbnailProgressState.NoProgress)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public ThumbnailProgressState ProgressState
        {
            get { return this._progressState; }
            set
            {
                switch (value)
                {
                    case ThumbnailProgressState.NoProgress:
                    case ThumbnailProgressState.Indeterminate:
                    case ThumbnailProgressState.Normal:
                    case ThumbnailProgressState.Error:
                    case ThumbnailProgressState.Paused:
                        this._progressState = value;
                        this.OnProgressStateChanged(new EventArgs());
                        break;

                    default:
                        throw new InvalidEnumArgumentException("The value is not a member of the ADBMailer.Forms.ProgressForm.ThumbnailProgressState enumeration.");
                }
            }
        }

        //
        // Summary:
        //     Gets or sets the current position of the progress bar.
        //
        // Returns:
        //     The position within the range of the progress bar. The default is 0.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The value specified is greater than the value of the ADBMailer.Forms.ProgressForm.MaximumProgressValue
        //     property. -or- The value specified is less than 0.
        [Browsable(true)]
        [DefaultValue(0)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int ProgressValue
        {
            get => this._progressValue;
            set
            {
                if (value < this._minimumProgressValue)
                {
                    throw new ArgumentOutOfRangeException("ProgressValue", "The value specified is smaller than the value of the ADBMailer.Forms.ProgressForm.MinimumProgressValue property.");
                }
                if (value > this._maximumProgressValue)
                {
                    throw new ArgumentOutOfRangeException("ProgressValue", "The value specified is greater than the value of the ADBMailer.Forms.ProgressForm.MaximumProgressValue property.");
                }
                this._progressValue = value;
                this.OnValueChanged(new EventArgs());
            }
        }

        //
        // Summary:
        //     Gets or sets the minimum value of the range of the control.
        //
        // Returns:
        //     The minimum value of the range. The default is 0.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The value specified is greather than or equal to MaximumProgressValue.
        [Browsable(true)]
        [DefaultValue(0)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int MinimumProgressValue
        {
            get => this._minimumProgressValue;
            set
            {
                if (value >= this._maximumProgressValue)
                {
                    throw new ArgumentOutOfRangeException("MinimumProgressValue", "The value specified is greather than MaximumProgressValue.");
                }
                this._minimumProgressValue = value;
                if (this._progressValue < value)
                {
                    this._progressValue = value;
                }
                this.OnMinimumProgressValueChanged(new EventArgs());
            }
        }

        //
        // Summary:
        //     Gets or sets the maximum value of the range of the control.
        //
        // Returns:
        //     The maximum value of the range. The default is 100.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The value specified is less or equal to than MinimumProgressValue.
        [Browsable(true)]
        [DefaultValue(100)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int MaximumProgressValue
        {
            get => this._maximumProgressValue;
            set
            {
                if (value <= this._minimumProgressValue)
                {
                    throw new ArgumentOutOfRangeException("MaximumProgressValue", "The value specified is less than MinimumProgressValue.");
                }
                this._maximumProgressValue = value;
                if (this._progressValue > value)
                {
                    this._progressValue = value;
                }
                this.OnMaximumProgressValueChanged(new EventArgs());
            }
        }

        private void OnProgressStateChanged(EventArgs _) => this.SetProgressState();

        private void OnValueChanged(EventArgs _) => this.SetProgressValue();

        private void OnMinimumProgressValueChanged(EventArgs _) => this.SetProgressValue();

        private void OnMaximumProgressValueChanged(EventArgs _) => this.SetProgressValue();

        protected override void WndProc(ref Message m)
        {
            if (RegisteredTaskbar != null && m.Msg == RegisteredTaskbar.TaskbarButtonHandle)
            {
                this.SetProgressState();
            }
            base.WndProc(ref m);
        }

        private void SetProgressState()
        {
            if (RegisteredTaskbar != null)
            {
                RegisteredTaskbar.TaskbarList.SetProgressState(Handle, this._progressState);
                this.SetProgressValue();
            }
        }

        private void SetProgressValue()
        {
            if (RegisteredTaskbar != null)
            {
                // must be Windows7orGreater
                switch (_progressState)
                {
                    case ThumbnailProgressState.Normal:
                    case ThumbnailProgressState.Error:
                    case ThumbnailProgressState.Paused:
                        RegisteredTaskbar.TaskbarList.SetProgressValue(Handle, (ulong)(this._progressValue - this._minimumProgressValue), (ulong)(this._maximumProgressValue - this._minimumProgressValue));
                        break;
                }
            }
        }

        private static CRegisteredTaskbar? RegisteredTaskbar
        {
            get
            {
                if (_registeredTaskbarFetched)
                {
                    return _registeredTaskbar;
                }
                try
                {
                    lock (typeof(ProgressForm))
                    {
                        if (!_registeredTaskbarFetched)
                        {
                            _registeredTaskbarFetched = true;
                            // Requires Windows 7 or later
                            var osVersion = Environment.OSVersion.Version;
                            if (osVersion.Major > 6 || (osVersion.Major == 6 && osVersion.Minor > 0))
                            {
                                var taskbarButtonHandle = RegisterWindowMessage("TaskbarButtonCreated");
                                if (taskbarButtonHandle != 0)
                                {
                                    var taskbarList = (ITaskbarList3)new CTaskbarList();
                                    _registeredTaskbar = new CRegisteredTaskbar(taskbarList, taskbarButtonHandle);
                                }
                            }
                        }
                    }
                }
                catch { }
                return _registeredTaskbar;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern uint RegisterWindowMessage(string message);

        [ComImport()]
        [Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface ITaskbarList3
        {
            // ITaskbarList
            [PreserveSig]
            void HrInit();

            [PreserveSig]
            void AddTab(IntPtr hwnd);

            [PreserveSig]
            void DeleteTab(IntPtr hwnd);

            [PreserveSig]
            void ActivateTab(IntPtr hwnd);

            [PreserveSig]
            void SetActiveAlt(IntPtr hwnd);

            // ITaskbarList2
            [PreserveSig]
            void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

            // ITaskbarList3
            void SetProgressValue(IntPtr hwnd, UInt64 ullCompleted, UInt64 ullTotal);

            void SetProgressState(IntPtr hwnd, ThumbnailProgressState tbpFlags);
        }

        [Guid("56FDF344-FD6D-11d0-958A-006097C9A090")]
        [ClassInterface(ClassInterfaceType.None)]
        [ComImport()]
        private class CTaskbarList
        { }

        private class CRegisteredTaskbar
        {
            public readonly ITaskbarList3 TaskbarList;
            public readonly uint TaskbarButtonHandle;

            public CRegisteredTaskbar(ITaskbarList3 taskbarList, uint taskbarButtonHandle)
            {
                this.TaskbarList = taskbarList;
                this.TaskbarButtonHandle = taskbarButtonHandle;
            }
        }
    }

    public enum ThumbnailProgressState : uint
    {
        /// <summary>
        /// No progress is displayed.
        /// </summary>
        NoProgress = 0,

        /// <summary>
        /// The progress is indeterminate (marquee).
        /// </summary>
        Indeterminate = 0x1,

        /// <summary>
        /// Normal progress is displayed.
        /// </summary>
        Normal = 0x2,

        /// <summary>
        /// An error occurred (red).
        /// </summary>
        Error = 0x4,

        /// <summary>
        /// The operation is paused (yellow).
        /// </summary>
        Paused = 0x8
    }
}