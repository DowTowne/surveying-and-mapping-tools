using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DropDrapFileSimple
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void InitListView(ListView listView)
        {
            listView.SmallImageList = new ImageList();
            listView.LargeImageList = new ImageList();

            listView.View = View.Details;
            listView.AllowDrop = true;
        }

        private void ListFolder()
        {
            ListFolder(labelCurFolder.Text);
        }

        /// <summary>
        /// List files in the folder
        /// </summary>
        /// <param name="directory">the directory of the folder</param>
        private void ListFolder(string directory)
        {
            labelCurFolder.Text = directory;

            String[] fileList = System.IO.Directory.GetFiles(directory);
            listViewFolder.Items.Clear();
            listViewFolder.Columns.Clear();
            listViewFolder.Columns.Add("Name", 300);
            listViewFolder.Columns.Add("Size", 100);
            listViewFolder.Columns.Add("Time", 200);

            foreach (string fileName in fileList)
            {
                //Show file name
                ListViewItem itemName = new ListViewItem(System.IO.Path.GetFileName(fileName));
                itemName.Tag = fileName;

                //Show file icon
                IconImageProvider iconImageProvider = new IconImageProvider(listViewFolder.SmallImageList, listViewFolder.LargeImageList);
                itemName.ImageIndex = iconImageProvider.GetIconImageIndex(fileName);

                //Show file size
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
                long size = fileInfo.Length;

                String strSize;
                if (size < 1024)
                {
                    strSize = size.ToString();
                }
                else if (size < 1024 * 1024)
                {
                    strSize = String.Format("{0:###.##}KB", (float)size / 1024);
                }
                else if (size < 1024 * 1024 * 1024)
                {
                    strSize = String.Format("{0:###.##}MB", (float)size / (1024 * 1024));
                }
                else
                {
                    strSize = String.Format("{0:###.##}GB", (float)size / (1024 * 1024 * 1024));
                }

                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
                subItem.Text = strSize;
                subItem.Tag = size;
                itemName.SubItems.Add(subItem);

                //Show file time
                subItem = new ListViewItem.ListViewSubItem();
                DateTime fileTime = System.IO.File.GetLastWriteTime(fileName);

                subItem.Text = (string)fileTime.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"); ;
                subItem.Tag = fileTime;

                itemName.SubItems.Add(subItem);
                listViewFolder.Items.Add(itemName);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitListView(listViewFolder);
            ListFolder(Environment.CurrentDirectory);
        }

        private void buttonSelFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                ListFolder(folderBrowserDialog.SelectedPath);
            }
        }

        private void listViewFolder_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                String[] files = e.Data.GetData(DataFormats.FileDrop, false) as String[];

                //Copy file from external application
                foreach (string srcfile in files)
                {
                    string destFile = labelCurFolder.Text + "\\" + System.IO.Path.GetFileName(srcfile);
                    if (System.IO.File.Exists(destFile))
                    {
                        if (MessageBox.Show(string.Format("This folder already contains a file named {0}, would you like to replace the existing file", System.IO.Path.GetFileName(srcfile)),
                            "Confirm File Replace", MessageBoxButtons.YesNo, MessageBoxIcon.None) != DialogResult.Yes)
                        {
                            continue;
                        }
                    }

                    System.IO.File.Copy(srcfile, destFile, true);
                }

                //List current folder
                ListFolder();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void listViewFolder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void listViewFolder_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listViewFolder.SelectedItems.Count <= 0)
                {
                    return;
                }

                //put selected files into a string array

                string[] files = new String[listViewFolder.SelectedItems.Count];

                int i = 0;
                foreach (ListViewItem item in listViewFolder.SelectedItems)
                {
                    files[i++] = item.Tag.ToString();
                }

                //create a dataobject holding this array as a filedrop

                DataObject data = new DataObject(DataFormats.FileDrop, files);

                //also add the selection as textdata

                data.SetData(DataFormats.StringFormat, files[0]);

                //Do DragDrop
                DoDragDrop(data, DragDropEffects.Copy);
            } 
        }
    }
}