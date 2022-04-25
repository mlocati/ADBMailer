﻿namespace ADBMailer
{
    public partial class frmMapDocs : Form
    {
        private const string FIELD_EMAIL_RECIPIENTS = "Destinatari email";
        private const string FIELD_MEMBER_NAME = "Nome socio";

        public readonly Mapping Mapping;

        private object? _selectedField = null;

        private void SetSelectedField(object? value)
        {
            this.StoreCurrentSelection();
            this.lsbHeader.SelectedItems.Clear();
            this.lnkClearSelected.Visible = this.lsbHeader.Visible = false;
            if (value is WordMapper.Field x)
            {
                this.lsbHeader.SelectionMode = SelectionMode.One;
                if (this.Mapping.SelectedWordFields[x.Name] != null)
                {
                    this.lsbHeader.SelectedItem = this.Mapping.SelectedWordFields[x.Name];
                }
                this.lnkClearSelected.Visible = this.lsbHeader.Visible = true;
            }
            else if (value is string s)
            {
                switch (s)
                {
                    case FIELD_EMAIL_RECIPIENTS:
                        this.lsbHeader.SelectionMode = SelectionMode.MultiExtended;
                        foreach (var field in this.Mapping.RecipientFields)
                        {
                            this.lsbHeader.SelectedItems.Add(field);
                        }
                        this.lnkClearSelected.Visible = this.lsbHeader.Visible = true;
                        break;

                    case FIELD_MEMBER_NAME:
                        this.lsbHeader.SelectionMode = SelectionMode.One;
                        this.lsbHeader.SelectedItem = this.Mapping.MemberNameField;
                        this.lnkClearSelected.Visible = this.lsbHeader.Visible = true;
                        break;
                }
            }
            this._selectedField = value;
            this.lsbField.Refresh();
        }

        public frmMapDocs(ExcelMapper.Header[] excelHeaders, WordMapper.Field[] wordFields, Mapping? oldMapping)
        {
            InitializeComponent();
            if (Program.ExeIcon != null)
            {
                this.Icon = Program.ExeIcon;
            }
            this.Mapping = new Mapping(excelHeaders, wordFields, oldMapping);
            if (oldMapping == null)
            {
                this.Mapping.AutoAssociate();
            }
            this.lsbField.DrawMode = DrawMode.OwnerDrawVariable;
            this.lsbField.Items.Clear();
            this.lsbField.Items.Add(FIELD_EMAIL_RECIPIENTS);
            this.lsbField.Items.Add(FIELD_MEMBER_NAME);
            this.lsbField.Items.AddRange(this.Mapping.WordFields);
            this.lsbHeader.Items.AddRange(this.Mapping.ExcelHeaders);
            this.UpdateSelectedField();
            object? selectedField = null;
            foreach (var item in this.lsbField.Items)
            {
                if (this.ShouldHighlightFieldItem(item))
                {
                    selectedField = item;
                    break;
                }
            }
            this.lsbField.SelectedItem = selectedField ?? this.lsbField.Items[0];
        }

        private void lsbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateSelectedField();
        }

        private void UpdateSelectedField()
        {
            this.SetSelectedField(this.lsbField.SelectedItem);
        }

        private void StoreCurrentSelection()
        {
            if (this._selectedField == null)
            {
                return;
            }
            if (this._selectedField is WordMapper.Field x)
            {
                this.Mapping.SelectedWordFields[x.Name] = this.lsbHeader.SelectedItem as ExcelMapper.Header;
                return;
            }
            if (this._selectedField is string s)
            {
                switch (s)
                {
                    case FIELD_EMAIL_RECIPIENTS:
                        this.Mapping.RecipientFields = this.lsbHeader.SelectedItems.Cast<ExcelMapper.Header>().ToArray();
                        break;

                    case FIELD_MEMBER_NAME:
                        this.Mapping.MemberNameField = this.lsbHeader.SelectedItem as ExcelMapper.Header;
                        break;
                }
                return;
            }
        }

        private void tnOk_Click(object sender, EventArgs e)
        {
            this.StoreCurrentSelection();
            if (this.Mapping.RecipientFields.Length == 0)
            {
                this.lsbField.SelectedItem = FIELD_EMAIL_RECIPIENTS;
                MessageBox.Show(this, "Selezionare almeno un campo contenente l'indirizzo email del destinatario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.Mapping.MemberNameField == null)
            {
                this.lsbField.SelectedItem = FIELD_MEMBER_NAME;
                MessageBox.Show(this, "Selezionare il campo contenente il nome del socio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (var wordField in this.Mapping.WordFields)
            {
                if (this.Mapping.SelectedWordFields[wordField.Name] == null)
                {
                    this.lsbField.SelectedItem = wordField;
                    MessageBox.Show(this, $"Selezionare il campo corrispondente a {wordField.Name}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void lnkClearSelected_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.lsbHeader.SelectedItems.Clear();
        }

        private bool ShouldHighlightFieldItem(object? fieldItem)
        {
            if (fieldItem is WordMapper.Field x)
            {
                return this.Mapping.SelectedWordFields[x.Name] == null;
            }
            if (fieldItem is string s)
            {
                switch (s)
                {
                    case FIELD_EMAIL_RECIPIENTS:
                        return this.Mapping.RecipientFields.Length == 0;

                    case FIELD_MEMBER_NAME:
                        return this.Mapping.MemberNameField == null;
                }
            }
            return false;
        }

        private void lsbField_DrawItem(object sender, DrawItemEventArgs e)
        {
            var font = e.Font ?? this.lsbField.Font;
            var item = this.lsbField.Items[e.Index];
            if (this.ShouldHighlightFieldItem(item))
            {
                font = new Font(font, FontStyle.Bold);
            }
            e.DrawBackground();
            e.Graphics.DrawString(item.ToString(), font, new SolidBrush(e.ForeColor), e.Bounds);
            e.DrawFocusRectangle();
        }
    }
}