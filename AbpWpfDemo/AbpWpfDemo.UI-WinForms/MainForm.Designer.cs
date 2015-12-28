namespace AbpWpfDemo.UI_WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadAllPeople = new System.Windows.Forms.Button();
            this.lstPeople = new System.Windows.Forms.ListView();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadAllPeople
            // 
            this.btnLoadAllPeople.Location = new System.Drawing.Point(12, 12);
            this.btnLoadAllPeople.Name = "btnLoadAllPeople";
            this.btnLoadAllPeople.Size = new System.Drawing.Size(518, 23);
            this.btnLoadAllPeople.TabIndex = 0;
            this.btnLoadAllPeople.Text = "Load all people";
            this.btnLoadAllPeople.UseVisualStyleBackColor = true;
            this.btnLoadAllPeople.Click += new System.EventHandler(this.btnLoadAllPeople_Click);
            // 
            // lstPeople
            // 
            this.lstPeople.Location = new System.Drawing.Point(12, 41);
            this.lstPeople.Name = "lstPeople";
            this.lstPeople.Size = new System.Drawing.Size(518, 324);
            this.lstPeople.TabIndex = 1;
            this.lstPeople.UseCompatibleStateImageBehavior = false;
            this.lstPeople.View = System.Windows.Forms.View.List;
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(13, 373);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(183, 20);
            this.txtPersonName.TabIndex = 2;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Location = new System.Drawing.Point(202, 371);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(75, 23);
            this.btnAddPerson.TabIndex = 3;
            this.btnAddPerson.Text = "Add new person";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 405);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.lstPeople);
            this.Controls.Add(this.btnLoadAllPeople);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadAllPeople;
        private System.Windows.Forms.ListView lstPeople;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Button btnAddPerson;
    }
}

