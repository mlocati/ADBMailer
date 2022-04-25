namespace ADBMailer.CustomControls
{
    internal class DoubleBufferedDataGridView : System.Windows.Forms.DataGridView
    {
        public DoubleBufferedDataGridView()
        {
            this.DoubleBuffered = true;
        }
    }
}