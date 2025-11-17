using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudyProcessManagement.Views.Teacher.Controls
{
    public class ContentControl : UserControl
    {
        private TableLayoutPanel mainLayout;
        private Panel headerPanel;
        private Label lblTitle;
        private ComboBox cboCourse;
        private Button btnAddSection;
        private SplitContainer splitContainer;
        private Panel treePanel;
        private TreeView tvContent;
        private Panel detailPanel;
        private Label lblDetailTitle;
        private TextBox txtLessonName;
        private TextBox txtLessonDescription;
        private Button btnSave;
        private Button btnAddLesson;

        public ContentControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.mainLayout = new TableLayoutPanel();
            this.headerPanel = new Panel();
            this.lblTitle = new Label();
            this.cboCourse = new ComboBox();
            this.btnAddSection = new Button();
            this.splitContainer = new SplitContainer();
            this.treePanel = new Panel();
            this.tvContent = new TreeView();
            this.detailPanel = new Panel();
            this.lblDetailTitle = new Label();
            this.txtLessonName = new TextBox();
            this.txtLessonDescription = new TextBox();
            this.btnSave = new Button();
            this.btnAddLesson = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();

            // mainLayout
            this.mainLayout.Dock = DockStyle.Fill;
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.RowCount = 2;
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.mainLayout.Padding = new Padding(8);

            // headerPanel
            this.headerPanel.Dock = DockStyle.Fill;
            this.headerPanel.Padding = new Padding(8);

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.Text = "Quản lý Nội dung";
            this.lblTitle.Dock = DockStyle.Left;
            this.lblTitle.Width = 300;
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // cboCourse
            this.cboCourse.Size = new Size(280, 30);
            this.cboCourse.Font = new Font("Segoe UI", 9.5F);
            this.cboCourse.Location = new Point(this.headerPanel.Width - 440, 18);
            this.cboCourse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCourse.Items.AddRange(new object[] {
                "Lập trình Web với React",
                "Python cơ bản",
                "JavaScript nâng cao",
                "Data Science với Python"
            });
            this.cboCourse.SelectedIndex = 0;

            // btnAddSection
            this.btnAddSection.Text = "+ Thêm chương";
            this.btnAddSection.Size = new Size(140, 38);
            this.btnAddSection.Location = new Point(this.headerPanel.Width - 148, 13);
            this.btnAddSection.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnAddSection.BackColor = Color.FromArgb(76, 175, 80);
            this.btnAddSection.ForeColor = Color.White;
            this.btnAddSection.FlatStyle = FlatStyle.Flat;
            this.btnAddSection.FlatAppearance.BorderSize = 0;
            this.btnAddSection.Font = new Font("Segoe UI", 9.5F);
            this.btnAddSection.Cursor = Cursors.Hand;

            this.btnAddSection.MouseEnter += (s, e) =>
            {
                this.btnAddSection.BackColor = Color.FromArgb(56, 142, 60);
            };
            this.btnAddSection.MouseLeave += (s, e) =>
            {
                this.btnAddSection.BackColor = Color.FromArgb(76, 175, 80);
            };

            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.cboCourse);
            this.headerPanel.Controls.Add(this.btnAddSection);

            // splitContainer
            this.splitContainer.Dock = DockStyle.Fill;
            this.splitContainer.SplitterDistance = 350;
            this.splitContainer.BorderStyle = BorderStyle.FixedSingle;

            // treePanel
            this.treePanel.Dock = DockStyle.Fill;
            this.treePanel.Padding = new Padding(5);

            // tvContent
            this.tvContent.Dock = DockStyle.Fill;
            this.tvContent.Font = new Font("Segoe UI", 10F);
            this.tvContent.BackColor = Color.White;
            this.tvContent.BorderStyle = BorderStyle.None;
            this.tvContent.ItemHeight = 28;

            // Add sample data
            var courseNode = new TreeNode("📚 Lập trình Web với React");
            courseNode.NodeFont = new Font("Segoe UI", 10F, FontStyle.Bold);

            var section1 = new TreeNode("📖 Chương 1: Giới thiệu");
            section1.NodeFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            section1.Nodes.Add(new TreeNode("📄 Bài 1: Tổng quan về React"));
            section1.Nodes.Add(new TreeNode("📄 Bài 2: Cài đặt môi trường"));
            section1.Nodes.Add(new TreeNode("📄 Bài 3: Component đầu tiên"));

            var section2 = new TreeNode("📖 Chương 2: State và Props");
            section2.NodeFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            section2.Nodes.Add(new TreeNode("📄 Bài 4: Hiểu về State"));
            section2.Nodes.Add(new TreeNode("📄 Bài 5: Props là gì?"));

            courseNode.Nodes.Add(section1);
            courseNode.Nodes.Add(section2);

            this.tvContent.Nodes.Add(courseNode);
            this.tvContent.ExpandAll();

            this.treePanel.Controls.Add(this.tvContent);
            this.splitContainer.Panel1.Controls.Add(this.treePanel);

            // detailPanel
            this.detailPanel.Dock = DockStyle.Fill;
            this.detailPanel.Padding = new Padding(15);
            this.detailPanel.AutoScroll = true;

            // lblDetailTitle
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblDetailTitle.Text = "Chi tiết bài học";
            this.lblDetailTitle.Location = new Point(15, 15);

            // Label for Lesson Name
            var lblName = new Label();
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F);
            lblName.Text = "Tên bài học:";
            lblName.Location = new Point(15, 60);

            // txtLessonName
            this.txtLessonName.Location = new Point(15, 85);
            this.txtLessonName.Size = new Size(550, 30);
            this.txtLessonName.Font = new Font("Segoe UI", 10F);
            this.txtLessonName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Label for Description
            var lblDesc = new Label();
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 10F);
            lblDesc.Text = "Mô tả:";
            lblDesc.Location = new Point(15, 130);

            // txtLessonDescription
            this.txtLessonDescription.Location = new Point(15, 155);
            this.txtLessonDescription.Size = new Size(550, 150);
            this.txtLessonDescription.Font = new Font("Segoe UI", 10F);
            this.txtLessonDescription.Multiline = true;
            this.txtLessonDescription.ScrollBars = ScrollBars.Vertical;
            this.txtLessonDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // btnAddLesson
            this.btnAddLesson.Text = "+ Thêm bài học";
            this.btnAddLesson.Size = new Size(130, 38);
            this.btnAddLesson.Location = new Point(15, 320);
            this.btnAddLesson.BackColor = Color.FromArgb(33, 150, 243);
            this.btnAddLesson.ForeColor = Color.White;
            this.btnAddLesson.FlatStyle = FlatStyle.Flat;
            this.btnAddLesson.FlatAppearance.BorderSize = 0;
            this.btnAddLesson.Font = new Font("Segoe UI", 9.5F);
            this.btnAddLesson.Cursor = Cursors.Hand;

            this.btnAddLesson.MouseEnter += (s, e) =>
            {
                this.btnAddLesson.BackColor = Color.FromArgb(25, 118, 210);
            };
            this.btnAddLesson.MouseLeave += (s, e) =>
            {
                this.btnAddLesson.BackColor = Color.FromArgb(33, 150, 243);
            };

            // btnSave
            this.btnSave.Text = "💾 Lưu";
            this.btnSave.Size = new Size(130, 38);
            this.btnSave.Location = new Point(155, 320);
            this.btnSave.BackColor = Color.FromArgb(76, 175, 80);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new Font("Segoe UI", 9.5F);
            this.btnSave.Cursor = Cursors.Hand;

            this.btnSave.MouseEnter += (s, e) =>
            {
                this.btnSave.BackColor = Color.FromArgb(56, 142, 60);
            };
            this.btnSave.MouseLeave += (s, e) =>
            {
                this.btnSave.BackColor = Color.FromArgb(76, 175, 80);
            };

            this.detailPanel.Controls.Add(this.lblDetailTitle);
            this.detailPanel.Controls.Add(lblName);
            this.detailPanel.Controls.Add(this.txtLessonName);
            this.detailPanel.Controls.Add(lblDesc);
            this.detailPanel.Controls.Add(this.txtLessonDescription);
            this.detailPanel.Controls.Add(this.btnAddLesson);
            this.detailPanel.Controls.Add(this.btnSave);

            this.splitContainer.Panel2.Controls.Add(this.detailPanel);

            this.mainLayout.Controls.Add(this.headerPanel, 0, 0);
            this.mainLayout.Controls.Add(this.splitContainer, 0, 1);

            this.Controls.Add(this.mainLayout);
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
        }
    }
}