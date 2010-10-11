using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;

namespace TestngppAddin
{
    public partial class CommandBarViewer : AddInForm
    {
        public CommandBarViewer()
        {
            InitializeComponent();
        }

        private void CommandBarViewer_Load(object sender, EventArgs e)
        {
            BindCommandBars();
        }

        private void BindCommandBars()
        {
            CommandBars cmdBars = (DTEObject.CommandBars as CommandBars);

            #region SortedNames

            List<string> names = new List<string>(cmdBars.Count);
            foreach (CommandBar bar in cmdBars)
            {
                names.Add(bar.Name);
            }

            names.Sort();
            foreach (string name in names)
            {
                TreeNode node = new TreeNode();
                node.Text = name;
                node.Tag = "bar";
                // Add a dummy node
                node.Nodes.Add("dummyNode");

                tvCommandBars.Nodes.Add(node);
            }

            #endregion
        }

        private void tvCommandBars_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            string nodeType = node.Tag as string;

            if (nodeType == "bar")
            {
                FillBar(node);
            }
            else if (nodeType == "popup")
            {
                FillPopup(node);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                StringBuilder result = new StringBuilder();
                foreach (TreeNode node in tvCommandBars.Nodes)
                {
                    result.AppendLine(node.Text);
                }

                File.WriteAllText(dlgSave.FileName, result.ToString());
            }
        }

        private void FillBar(TreeNode cmdBarNode)
        {
            cmdBarNode.Nodes.Clear();
            CommandBar bar = (DTEObject.CommandBars as CommandBars)[cmdBarNode.Text];
            foreach (CommandBarControl ctrl in bar.Controls)
            {
                if (!string.IsNullOrEmpty(ctrl.Caption))
                {
                    TreeNode ctrlNode = new TreeNode();
                    ctrlNode.Text = ctrl.Caption.Replace("&", "");

                    if (ctrl is CommandBarPopup)
                    {
                        ctrlNode.Tag = "popup";
                        // Add a dummy node
                        ctrlNode.Nodes.Add("dummyNode");
                    }

                    cmdBarNode.Nodes.Add(ctrlNode);
                }
            }
        }

        private void FillPopup(TreeNode popupNode)
        {
            popupNode.Nodes.Clear();
            CommandBar bar = (DTEObject.CommandBars as CommandBars)[popupNode.Parent.Text];
            CommandBarPopup popup = bar.Controls[popupNode.Text] as CommandBarPopup;

            foreach (CommandBarControl ctrl in popup.Controls)
            {
                if (!string.IsNullOrEmpty(ctrl.Caption))
                {
                    TreeNode ctrlNode = new TreeNode();
                    ctrlNode.Text = ctrl.Caption.Replace("&", "");
                    popupNode.Nodes.Add(ctrlNode);
                }
            }
        }
    }
}
