using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Matheus_Almeida___Menu_Dinamico
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                carregaMenu2();
        }

        private void carregaMenu2()
        {
            using (SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=trabalhos;Data Source=."))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select menuid, descricao,link, parentid  from MENU order by menuid", conn))
                {
                    SqlDataReader dtr = cmd.ExecuteReader();
                    while (dtr.Read())
                    {
                        MenuItem mi = null;

                        mi = new MenuItem(dtr["descricao"].ToString(), dtr["menuid"].ToString());

                        //Verifica se a linha é raiz
                        if (dtr["parentid"] == DBNull.Value)
                        {
                            //Adiciona um novo nó no Menu

                            Menu1.Items.Add(mi);
                        }
                        else
                        {
                            miPaiNo = null;
                            MenuItem miPai = localizaMenuPai(Menu1.Items, (int)dtr["parentid"]);
                            mi.Text = dtr["descricao"].ToString();
                            mi.NavigateUrl = dtr["link"].ToString();
                            if (miPai != null) miPai.ChildItems.Add(mi);
                        }

                    }
                }
            }
        }





        static MenuItem miPaiNo = null;

        private MenuItem localizaMenuPai(MenuItemCollection menuItemCollection, int PaiId)
        {
            foreach (MenuItem mi in menuItemCollection)
            {
                if (mi.Value.Equals(PaiId.ToString()))
                    miPaiNo = mi;
                else
                    if (mi.ChildItems != null)
                        this.localizaMenuPai(mi.ChildItems, PaiId);
            }
            return miPaiNo;
        }
    }
}