using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba.UserInterface
{
    public partial class frmCategoria : Form
    {
        private readonly SdCategoria _sdCategoria = new SdCategoria();

        public frmCategoria()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            var entity = new Categoria()
            {
                Id = string.IsNullOrEmpty(txtId.Text) ? 0 : Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text
            };
            _sdCategoria.Create(entity);
            txtId.Text = Convert.ToString(entity.Id);

        }

        
    }
}
