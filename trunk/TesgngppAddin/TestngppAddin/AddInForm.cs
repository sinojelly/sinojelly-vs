using System;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;

namespace TestngppAddin
{
    public class AddInForm : Form
    {
        private DTE2 _dteObj = null;
        public DTE2 DTEObject
        {
            get
            {
                return _dteObj;
            }
            set
            {
                _dteObj = value;
            }
        }
    }
}
