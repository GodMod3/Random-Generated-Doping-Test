using System.Configuration;
using System.Data.SqlClient;

namespace DopingTest
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.GenerateButton = new System.Windows.Forms.Button();
            this.dopingTestList = new System.Windows.Forms.DataGridView();
            this.numberOfTestMembers = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ListOfVerbände = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dopingTestList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfTestMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(662, 115);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GenerateButton.Size = new System.Drawing.Size(98, 23);
            this.GenerateButton.TabIndex = 0;
            this.GenerateButton.Text = "Liste generieren";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // dopingTestList
            // 
            this.dopingTestList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dopingTestList.Location = new System.Drawing.Point(28, 69);
            this.dopingTestList.Name = "dopingTestList";
            this.dopingTestList.Size = new System.Drawing.Size(469, 343);
            this.dopingTestList.TabIndex = 1;
            // 
            // numberOfTestMembers
            // 
            this.numberOfTestMembers.Location = new System.Drawing.Point(614, 116);
            this.numberOfTestMembers.Name = "numberOfTestMembers";
            this.numberOfTestMembers.Size = new System.Drawing.Size(42, 20);
            this.numberOfTestMembers.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(530, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gastgeber";
            // 
            // ListOfVerbände
            // 
            this.ListOfVerbände.FormattingEnabled = true;
            this.ListOfVerbände.Location = new System.Drawing.Point(592, 69);
            this.ListOfVerbände.Name = "ListOfVerbände";
            this.ListOfVerbände.Size = new System.Drawing.Size(168, 21);
            this.ListOfVerbände.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Anzahl Tester";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(24, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Liste der Testpersonen";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ListOfVerbände);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberOfTestMembers);
            this.Controls.Add(this.dopingTestList);
            this.Controls.Add(this.GenerateButton);
            this.Name = "MainWindow";
            this.Text = "Doping Test DRB";
            ((System.ComponentModel.ISupportInitialize)(this.dopingTestList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfTestMembers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }        

        #endregion

        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.DataGridView dopingTestList;
        private System.Windows.Forms.NumericUpDown numberOfTestMembers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ListOfVerbände;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

