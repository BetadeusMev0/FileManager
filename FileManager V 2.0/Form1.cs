using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;

namespace FileManager_V_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hotKeyLabel.Text = "HotKeys: \nDoubleClick - открыть файл\nDelete - удалить файл\nF2 - Переименовать файл\nctrl + c - Копировать\nctrl + v Вставить\nEnter - открыть для редактирования/просмотра\nctrl + S Сохранить отредактированный Файл";
            rootNode =
            directoryTree.Nodes.Add("C:");
            addTemp(rootNode);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;



        }





        DirectoryInfo rootDirectory = new DirectoryInfo("C:\\");
        TreeNode rootNode = null;




        private void AddNodes(DirectoryInfo directory, TreeNode node)
        {
            try
            {
                foreach (DirectoryInfo dir in directory.GetDirectories())
                {
                    addTemp(node.Nodes.Add(dir.Name));
                }

                foreach (FileInfo file in directory.GetFiles())
                {
                    node.Nodes.Add(file.Name);
                }
            }
            catch { }
        }

        private void addTemp(TreeNode node)
        {
            node.Nodes.Add("Заглушка");
        }

        private void directoryTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.Nodes.Clear();
            AddNodes(new DirectoryInfo(e.Node.FullPath), e.Node);
        }

        private void directoryTree_DoubleClick(object sender, EventArgs e)
        {

        }

        private void directoryTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                Process.Start(e.Node.FullPath);
            }
            catch { ErrorLabel.Text = "Не удалось открыть: " + e.Node.FullPath; }

        }

        private async void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (IsFile(focusedNode.FullPath))
                    {
                        richTextBox1.Text = File.ReadAllText(focusedNode.FullPath);
                        openedFile = focusedNode.FullPath;
                        try { pictureBox1.Image = Image.FromFile(focusedNode.FullPath); }
                        catch { }
                    }
                    break;

                case Keys.S:
                    if (e.Control) { File.WriteAllText(openedFile, richTextBox1.Text); ErrorLabel.Text = "Файл успешно сохранён"; }
                    break;
                case Keys.C:
                    if (e.Control) copiedFile = focusedNode;
                    break;
                case Keys.V:
                    if (e.Control && copiedFile != null) 
                    {
                        try
                        {
                            TreeNode node = null;

                            if (IsFile(focusedNode.FullPath)) node = focusedNode.Parent;

                            if (IsDirectory(focusedNode.FullPath)) node = focusedNode;

                            if (IsFile(copiedFile.FullPath))
                            {
                                File.Copy(copiedFile.FullPath, node.FullPath + "\\" + copiedFile.Text);
                                node.Nodes.Add(copiedFile.Text);
                            }
                            else if (IsDirectory(copiedFile.FullPath))
                            {
                                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory
                                (copiedFile.FullPath, node.FullPath + "\\" + copiedFile.Text);
                                node.Nodes.Add(copiedFile.Text);
                            }

                        }
                        catch { ErrorLabel.Text = "Копирование не удалось."; }
                    }
                    break;

                case Keys.F2:
                    if (IsFile(focusedNode.FullPath))
                    {
                        isFile = true;
                        tmp = focusedNode;
                        tmp2 = focusedNode.Parent;
                        var form = new Form2();
                        form.Tag = this;
                        form.FormClosing += Form_FormClosing;
                        form.Show();


                    }
                    else if (IsDirectory(focusedNode.FullPath))
                    {
                        isDirectory = true;
                        tmp = focusedNode;
                        tmp2 = focusedNode.Parent;
                        var form = new Form2();
                        form.Tag = this;
                        form.FormClosing += Form_FormClosing;
                        form.Show();
                    }

                    break;
                case Keys.Delete:
                    if (File.Exists(focusedNode.FullPath))
                    {
                        try { File.Delete(focusedNode.FullPath); focusedNode.Remove(); }
                        catch { ErrorLabel.Text = "Не удалось удалить файл: " + focusedNode.FullPath; }
                    }
                    else if (Directory.Exists(focusedNode.FullPath))
                    {
                        try { DeleteFileInDirectory(new(focusedNode.FullPath)); Directory.Delete(focusedNode.FullPath); focusedNode.Remove(); }
                        catch { ErrorLabel.Text = "Не удалось удалить файл: " + focusedNode.FullPath; }
                    }
                    break;
            }
        }

        private TreeNode copiedFile = null;



        public string newName = "";

        private bool isFile = false;
        private bool isDirectory = false;

        private TreeNode tmp = null;
        private TreeNode tmp2 = null;


        private string openedFile = null;


        private bool IsDirectory(string path)
        {
            if (Directory.Exists(path))
                return true;
            return false;
        }


        private void Form_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (isFile)
                File.Move(focusedNode.FullPath, focusedNode.Parent.FullPath + "\\" + newName);


            if (isDirectory)
                Directory.Move(focusedNode.FullPath, focusedNode.Parent.FullPath + "\\" + newName);



            tmp.Remove();

            if (isDirectory) addTemp(tmp2.Nodes.Add(newName));
            isDirectory = false;
            isFile = false;

        }

        private bool IsFile(string path)
        {
            if (File.Exists(path))
                return true;
            return false;
        }






        private void DeleteFileInDirectory(DirectoryInfo directory)
        {
            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                if (dir.GetFiles().Length > 0) DeleteFileInDirectory(dir);
                else dir.Delete();
            }

        }





        TreeNode focusedNode = null;

        private void directoryTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            focusedNode = e.Node;

        }






    }
}