using CrudsApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudsApi.DalHelper
{
    public class DalHelper : Controller
    {
        static string cadenaConexion = "data source=54.94.191.184,35863;initial catalog=discuy;user id=sa;password=2234;Connect Timeout=60";

        #region Bancos
        public static List<Bancos> GetBancos(int idCompany) //yjs 250419
        {
            cadenaConexion = SelectCadena(idCompany);
            List<Bancos> listabancos = new List<Bancos>();

            string sql = "select distinct * from bancos  ";

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaBanco");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaBanco"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                Bancos bancos = new Bancos()
                {
                    idBanco = Int32.Parse(drCurrent["idBanco"].ToString()),
                    descripcion = drCurrent["descripcion"].ToString(),
                    numerocuit = drCurrent["numerocuit"].ToString()
                };

                listabancos.Add(bancos);
            }
            return listabancos;
        }


        public static List<Bancos> Banco(int idBanco,int idCompany) //yjs 250419
        {
            cadenaConexion = SelectCadena(idCompany);
            var listabanco = new List<Bancos>();
            string sql = "select * from bancos where idBanco =" + idBanco;

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();     
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaBanco");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaBanco"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                Bancos bancos = new Bancos()
                {
                    idBanco = Int32.Parse(drCurrent["idBanco"].ToString()),
                    descripcion = drCurrent["descripcion"].ToString(),
                    numerocuit = drCurrent["numerocuit"].ToString()
                };

                listabanco.Add(bancos);
            }
            return listabanco;
        }

        public static bool AddEditBanco(Bancos banco, int idCompany) //yjs 250419
        {
            try
            {
                int reg = 0;
                cadenaConexion = SelectCadena(idCompany);
                var lSucces = true;
                string sql = "spAddEditBanco " + banco.idBanco + ",'" + banco.descripcion + "'," + banco.numerocuit;

                SqlConnection con = new SqlConnection(cadenaConexion);

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }

                return lSucces;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool deleteBanco(int idBanco, int idCompany) //yjs 260419
        {
                int reg = 0;
                cadenaConexion = SelectCadena(idCompany);
                var lSucces = true;
                string sql = "delete from bancos where idBanco = " + idBanco;

                SqlConnection con = new SqlConnection(cadenaConexion);

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return lSucces;

        }

        //public static bool deleteBanco(int idBanco, int idCompany) //yjs 260419
        //{
        //    try
        //    {
        //        int reg = 0;
        //        cadenaConexion = SelectCadena(idCompany);
        //        var lSucces = true;
        //        string sql = "delete from bancos where idBanco = " + idBanco;

        //        SqlConnection con = new SqlConnection(cadenaConexion);

        //        using (SqlCommand cmd = new SqlCommand(sql, con))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            con.Open();
        //            reg = cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //        return lSucces;

        //    }
        //    catch (Exception ex)
        //    {

        //        return false; ;
        //    }
        //}
        #endregion

        #region Cuentas
        public static List<CuentasView> GetCuentas(int idCompany) //yjs 030519, 040619
        {
            cadenaConexion = SelectCadena(idCompany);

            List<CuentasView> listacuentas = new List<CuentasView>();

            string sql = "select distinct a.*,b.descripcion nombretipo from cuentas a ";
            sql = sql + " inner join tiposcuentas b on a.idtipocuenta = b.idtipocuenta";

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaCuenta");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaCuenta"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                CuentasView cuentas = new CuentasView()
                {
                    idCuenta = Int32.Parse(drCurrent["idCuenta"].ToString()),
                    descripcion = drCurrent["descripcion"].ToString(),
                    recibeasientos = bool.Parse(drCurrent["recibeasientos"].ToString()),
                    ajustable = bool.Parse(drCurrent["ajustable"].ToString()),
                    idTipoCuenta = Int32.Parse(drCurrent["idTipoCuenta"].ToString()),
                    activo = bool.Parse(drCurrent["activo"].ToString()),
                    desTipo = drCurrent["nombretipo"].ToString(),
                    descriRecibe = bool.Parse(drCurrent["recibeasientos"].ToString()) ? "Si" : "No",
                    descriAjusta = bool.Parse(drCurrent["ajustable"].ToString()) ? "Si" : "No",
                    descriActivo = bool.Parse(drCurrent["activo"].ToString()) ? "Si" : "No",
                };

                listacuentas.Add(cuentas);
            }
            return listacuentas;
        }

        public static List<Cuentas> GetCuenta(int idCuenta,int idCompany) //yjs 060519
        {
            cadenaConexion = SelectCadena(idCompany);   

            List<Cuentas> listacuenta = new List<Cuentas>();

            string sql = "select distinct a.* from cuentas a where a.idCuenta = " + idCuenta;

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaCuenta");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaCuenta"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                Cuentas cuentas = new Cuentas()
                {
                    idCuenta = Int32.Parse(drCurrent["idCuenta"].ToString()),
                    descripcion = drCurrent["descripcion"].ToString(),
                    recibeasientos = bool.Parse(drCurrent["recibeasientos"].ToString()),
                    ajustable = bool.Parse(drCurrent["ajustable"].ToString()),
                    idTipoCuenta = Int32.Parse(drCurrent["idTipoCuenta"].ToString())
                };

                listacuenta.Add(cuentas);
            }
            return listacuenta;
        }

        public static List<TiposCuentas> GetTipoCuentas(int idCompany) //yjs 030519
        {
            cadenaConexion = SelectCadena(idCompany);

            List<TiposCuentas> listatipos = new List<TiposCuentas>();

            string sql = "select distinct * from tiposcuentas  ";

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaCuenta");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaCuenta"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                TiposCuentas tipocuenta = new TiposCuentas()
                {
                    idTipoCuenta = Int32.Parse(drCurrent["idTipoCuenta"].ToString()),
                    descripcion = drCurrent["descripcion"].ToString(),
                    asientosmanuales = bool.Parse(drCurrent["asientosmanuales"].ToString()),
                    activo = bool.Parse(drCurrent["activo"].ToString())
                };

                listatipos.Add(tipocuenta);
            }
            return listatipos;
        }

        public static bool AddEditCuenta(Cuentas cuenta, int idCompany) //yjs 060519
        {
            try
            {
                int reg = 0;
                cadenaConexion = SelectCadena(idCompany); 
                var lSucces = true;
                var intRecibe = cuenta.recibeasientos ? 1 : 0;
                var intAjusta = cuenta.ajustable ? 1 : 0;
                string sql = "spAddEditCuenta " + cuenta.idCuenta + ",'" + cuenta.descripcion + "'," + intRecibe + "," +
                     intAjusta + "," +  cuenta.idTipoCuenta + "," + cuenta.activo;

                SqlConnection con = new SqlConnection(cadenaConexion);

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }

                return lSucces;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool deleteCuenta(int idCuenta, int idCompany) //yjs 260419
        {
            int reg = 0;
            cadenaConexion = SelectCadena(idCompany);
            var lSucces = true;
            string sql = "delete from cuentas where idCuenta = " + idCuenta;

            SqlConnection con = new SqlConnection(cadenaConexion);

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = CommandType.Text;
                con.Open();
                reg = cmd.ExecuteNonQuery();
                con.Close();
            }
            return lSucces;

        }
        #endregion

        #region employee
        public static List<Employee> GetEmployees(int idCompany) //yjs 240519
        {
            cadenaConexion = SelectCadena(idCompany);
            List<Employee> listaemployees = new List<Employee>();

            string sql = "select distinct * from employee ";

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaEmployee");
            DataTable tblEmployee;
            tblEmployee = dsResultado.Tables["VistaEmployee"];

            foreach (DataRow drCurrent in tblEmployee.Rows)
            {
                Employee employee = new Employee()
                {
                    idEmployee = Int32.Parse(drCurrent["idEmployee"].ToString()),
                    fullName  = drCurrent["fullname"].ToString(),
                    email = drCurrent["email"].ToString(),
                    mobile = drCurrent["mobile"].ToString(),
                    city = drCurrent["city"].ToString(),
                    gender = Int32.Parse( drCurrent["gender"].ToString()),
                    department = Int32.Parse( drCurrent["department"].ToString()),
                    hireDate = DateTime.Parse( drCurrent["hireDate"].ToString()),
                    isPermanent = bool.Parse( drCurrent["isPermanent"].ToString())
                };

                listaemployees.Add(employee);
            }
            return listaemployees;
        }


        public static List<Employee> Employee(int idEmp, int idCompany) //yjs 250419
        {
            cadenaConexion = SelectCadena(idCompany);
            var listaemp = new List<Employee>();
            string sql = "select * from employee where idEmployee =" + idEmp;

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaEmp");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaEmp"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                Employee emplo = new Employee()
                {
                    idEmployee = Int32.Parse(drCurrent["idEmployee"].ToString()),
                    fullName = drCurrent["fullname"].ToString(),
                    email = drCurrent["email"].ToString(),
                    mobile = drCurrent["mobile"].ToString(),
                    city = drCurrent["city"].ToString(),
                    gender = Int32.Parse(drCurrent["gender"].ToString()),
                    department = Int32.Parse(drCurrent["department"].ToString()),
                    hireDate = DateTime.Parse(drCurrent["hireDate"].ToString()),
                    isPermanent = bool.Parse(drCurrent["isPermanent"].ToString())
                };

                listaemp.Add(emplo);
            }
            return listaemp;
        }

        public static bool AddEditEmployee(Employee employee, int idCompany) //yjs 240519
        {
            try
            {
                int reg = 0;

                var cFecha = employee.hireDate.ToString("yyyy-MM-dd") + " 00:00:00.000";
                cadenaConexion = SelectCadena(idCompany);
                var lSucces = true;
                string sql = "spAddEditEmployee " + employee.idEmployee + ",'" + employee.fullName + "','" + employee.email
                    + "','" + employee.mobile + "','" + employee.city + "'," + employee.gender + "," + employee.department
                    + ",'" + cFecha + "'," + employee.isPermanent;

                SqlConnection con = new SqlConnection(cadenaConexion);

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }

                return lSucces;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool deleteEmployee(int idEmployee, int idCompany) //yjs 240519
        {
            int reg = 0;
            cadenaConexion = SelectCadena(idCompany);
            var lSucces = true;
            string sql = "delete from employee where idEmployee = " + idEmployee;

            SqlConnection con = new SqlConnection(cadenaConexion);

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = CommandType.Text;
                con.Open();
                reg = cmd.ExecuteNonQuery();
                con.Close();
            }
            return lSucces;

        }

        //public static bool deleteBanco(int idBanco, int idCompany) //yjs 260419
        //{
        //    try
        //    {
        //        int reg = 0;
        //        cadenaConexion = SelectCadena(idCompany);
        //        var lSucces = true;
        //        string sql = "delete from bancos where idBanco = " + idBanco;

        //        SqlConnection con = new SqlConnection(cadenaConexion);

        //        using (SqlCommand cmd = new SqlCommand(sql, con))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            con.Open();
        //            reg = cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //        return lSucces;

        //    }
        //    catch (Exception ex)
        //    {

        //        return false; ;
        //    }
        //}
        #endregion

        #region Users

        public static List<Usuarios> GetUsers(int idCompany) //yjs 110619
        {
            cadenaConexion = SelectCadena(idCompany);
            List<Usuarios> listausers = new List<Usuarios>();

            string sql = "select distinct * from usuarios ";

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaUser");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaUser"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                Usuarios users = new Usuarios()
                {
                    idUsuario = Int32.Parse(drCurrent["idUsuario"].ToString()),
                    nombre = drCurrent["nombre"].ToString(),
                    password = drCurrent["password"].ToString()
                };

                listausers.Add(users);
            }
            return listausers;
        }


        public static List<Usuarios> OneUser(string nomUser, int idCompany) //yjs 110619
        {
            cadenaConexion = SelectCadena(idCompany);
            var listauser = new List<Usuarios>();
            string sql = "select * from usuarios where nombre =" + "'" + nomUser + "'";

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaUser");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaUser"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                Usuarios user = new Usuarios()
                {
                    idUsuario = Int32.Parse(drCurrent["idUsuario"].ToString()),
                    nombre = drCurrent["nombre"].ToString(),
                    password = drCurrent["password"].ToString()
                };

                listauser.Add(user);
            }
            return listauser;
        }

        #endregion

        #region Provedor
        public static List<Provedor> GetProvedores(int idCompany) //yjs 240619
        {
            cadenaConexion = SelectCadena(idCompany);
            List<Provedor> listprovs = new List<Provedor>();

            string sql = "select idProveedor,nombre from provedor where activo = 1 order by nombre ";

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaProv");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaProv"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                Provedor provs = new Provedor()
                {
                    idProveedor = Int32.Parse(drCurrent["idProveedor"].ToString()),
                    nombre = drCurrent["nombre"].ToString()
                };

                listprovs.Add(provs);
            }
            return listprovs;
        }
        #endregion

        #region Items
        public static List<Items> GetItems(int idCompany) //yjs 250619
        {
            cadenaConexion = SelectCadena(idCompany);
            List<Items> list = new List<Items>();

            string sql = "select * from items  order by name ";

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaItem");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaItem"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                Items item = new Items()
                {
                    itemId = Int32.Parse(drCurrent["itemId"].ToString()),
                    name = drCurrent["name"].ToString(),
                    price = float.Parse(drCurrent["price"].ToString())
                };

                list.Add(item);
            }
            return list;
        }
        #endregion

        #region Orders
        public static List<OrdersView> GetOrders(int idCompany) //yjs 260619
        {
            cadenaConexion = SelectCadena(idCompany);
            List<OrdersView> listaordenes = new List<OrdersView>();

            string sql = "select b.nombre,a.* from orders a inner join provedor b on a.idProveedor = b.idProveedor ";

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaOrder");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaOrder"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                OrdersView orden = new OrdersView()
                {
                    nombreProvedor = (drCurrent["nombre"].ToString()),
                    ordersId = Int32.Parse(drCurrent["ordersId"].ToString()),
                    orderNo = drCurrent["orderNo"].ToString(),
                    idProveedor = Int32.Parse(drCurrent["idProveedor"].ToString()),
                    pMethod = drCurrent["pMethod"].ToString(),
                    gTotal = float.Parse(drCurrent["gTotal"].ToString())
                    
                };

                listaordenes.Add(orden);
            }
            return listaordenes;
        }


        public static Response GetOrder(int idOrder, int idCompany) //yjs 270619
        {
            cadenaConexion = SelectCadena(idCompany);
            List<OrdersView> listaorden = new List<OrdersView>();

            string sql = "select b.nombre,a.* from orders a inner join provedor b on a.idProveedor = b.idProveedor where a.ordersId =" + idOrder;

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaOrder");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaOrder"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                OrdersView orden = new OrdersView()
                {
                    nombreProvedor = (drCurrent["nombre"].ToString()),
                    ordersId = Int32.Parse(drCurrent["ordersId"].ToString()),
                    orderNo = drCurrent["orderNo"].ToString(),
                    idProveedor = Int32.Parse(drCurrent["idProveedor"].ToString()),
                    pMethod = drCurrent["pMethod"].ToString(),
                    gTotal = float.Parse(drCurrent["gTotal"].ToString())

                };

                listaorden.Add(orden);
            }
//            con.Close();

            List<OrdersDetailView> detail = new List<OrdersDetailView>();

            sql = "select a.ordersDetailId,a.ordersId,a.itemId,a.Quantity,b.name itemName,b.price Precio,b.price * a.Quantity Total ";
            sql = sql + "from ordersdetail a ";
            sql = sql + "inner join items b on a.itemID = b.itemId ";
            sql = sql + "where a.ordersId =" + idOrder;

  //          con.Open();
            SqlDataAdapter adapter02 = new SqlDataAdapter(sql, con);
            DataSet dsResultado02 = new DataSet();
            adapter02.Fill(dsResultado02, "VistaDetail");
            DataTable tblDetail;
            tblDetail = dsResultado02.Tables["VistaDetail"];

            foreach (DataRow drCurrent in tblDetail.Rows)
            {
                OrdersDetailView orden = new OrdersDetailView()
                {
                    ordersDetailId = Int32.Parse(drCurrent["ordersDetailId"].ToString()),
                    ordersId = Int32.Parse(drCurrent["ordersId"].ToString()),
                    itemId = Int32.Parse(drCurrent["itemId"].ToString()),
                    Quantity = Int32.Parse(drCurrent["Quantity"].ToString()),
                    itemName = drCurrent["itemName"].ToString(),
                    Precio = float.Parse(drCurrent["precio"].ToString()),
                    Total = float.Parse(drCurrent["Total"].ToString())

                };

                detail.Add(orden);
            }

            var response = new Response();
            response.order = listaorden;
            response.detail = detail;
            return response;
        }

        public static bool AddOrder(Orders orden, int idCompany) //yjs 260619
        {
            try
            {
                int reg = 0;
                int nConsecutivo = 0;
                cadenaConexion = SelectCadena(idCompany);
                var lSucces = true;

                var cTotal = orden.gTotal + "";
                cTotal = cTotal.Replace(",", ".");

                string sql = "insert into orders (orderNo,idProveedor,pMethod,gTotal) output INSERTED.ordersId values ('"
                    + orden.orderNo + "'," + orden.idProveedor + ",'" + orden.pMethod + "'," + cTotal + ")";

                SqlConnection con = new SqlConnection(cadenaConexion);

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    //reg = cmd.ExecuteNonQuery();
                    nConsecutivo = (int)cmd.ExecuteScalar();
                    con.Close();
                }

                foreach (var item in orden.OrdersItems)
                {
                    sql = "insert into ordersDetail (ordersId,itemId,Quantity) values (" 
                        + nConsecutivo + "," + item.itemId + "," + item.Quantity + ")";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        reg = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                return lSucces;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool UpdateOrder(Orders orden, int idCompany) //yjs 280619
        {
            try
            {
                int reg = 0;
                cadenaConexion = SelectCadena(idCompany);
                var lSucces = true;

                var cTotal = orden.gTotal + "";
                cTotal = cTotal.Replace(",", ".");

                string sql = "update orders set idProveedor = " + orden.idProveedor +
                    ",pMethod = '" + orden.pMethod + "',gTotal = " + cTotal + 
                    " where ordersId = " + orden.ordersId;

                SqlConnection con = new SqlConnection(cadenaConexion);

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }

                //delete
                sql = "delete from ordersDetail where ordersId= " + orden.ordersId;

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }

                //end delete

                foreach (var item in orden.OrdersItems)
                {
                    sql = "insert into ordersDetail (ordersId,itemId,Quantity) values ("
                        + orden.ordersId + "," + item.itemId + "," + item.Quantity + ")";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        reg = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                return lSucces;

            }
            catch (Exception)
            {

                return false;
            }
        }


        public static bool deleteOrder(int idOrder, int idCompany) //yjs 280419
        {
            int reg = 0;
            cadenaConexion = SelectCadena(idCompany);
            var lSucces = true;
            string sql = "delete from ordersDetail where ordersId= " + idOrder;
            SqlConnection con = new SqlConnection(cadenaConexion);

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = CommandType.Text;
                con.Open();
                reg = cmd.ExecuteNonQuery();
                con.Close();
            }

            sql = "delete from orders where ordersId= " + idOrder;

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = CommandType.Text;
                con.Open();
                reg = cmd.ExecuteNonQuery();
                con.Close();
            }
            return lSucces;

        }

        #endregion

        #region clientes
        public static List<ClientesView> GetClientes(int idCompany) //yjs 290719
        {
            cadenaConexion = SelectCadena(idCompany);
            List<ClientesView> listaclientes = new List<ClientesView>();

            string sql = "select a.*,b.descripcion desCiudad, replace(convert(NVARCHAR, a.fechaAlta, 106), ' ', '/') fechaCorta " +
                "from ClientesCrud a inner join ciudades b on a.idCiudad = b.idCiudad ";

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaCliente");
            DataTable tblEmployee;
            tblEmployee = dsResultado.Tables["VistaCliente"];

            foreach (DataRow drCurrent in tblEmployee.Rows)
            {
                ClientesView cliente = new ClientesView()
                {
                    idCliente = Int32.Parse(drCurrent["idCliente"].ToString()),
                    descripcion = drCurrent["descripcion"].ToString(),
                    email = drCurrent["email"].ToString(),
                    mobile = drCurrent["mobile"].ToString(),
                    idCiudad = Int32.Parse(drCurrent["idCiudad"].ToString()),
                    fechaAlta = DateTime.Parse(drCurrent["fechaAlta"].ToString()),
                    activo = bool.Parse(drCurrent["activo"].ToString()),
                    desCiudad = drCurrent["desCiudad"].ToString(),
                    desActivo = bool.Parse(drCurrent["activo"].ToString()) ? "Si" : "No",
                    fechaCorta = drCurrent["fechaCorta"].ToString()
                };

                listaclientes.Add(cliente);
            }
            return listaclientes;
        }

        public static List<ClientesView> getCliente(int idCli, int idCompany) //yjs 290719
        {
            cadenaConexion = SelectCadena(idCompany);
            var listacli = new List<ClientesView>();
            string sql = "select * from ClientesCrud where idCliente =" + idCli;

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaCli");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaCli"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                ClientesView cliente = new ClientesView()
                {
                    idCliente = Int32.Parse(drCurrent["idCliente"].ToString()),
                    descripcion = drCurrent["descripcion"].ToString(),
                    email = drCurrent["email"].ToString(),
                    mobile = drCurrent["mobile"].ToString(),
                    idCiudad = Int32.Parse(drCurrent["idCiudad"].ToString()),
                    fechaAlta = DateTime.Parse(drCurrent["fechaAlta"].ToString()),
                    activo = bool.Parse(drCurrent["activo"].ToString()),
                    desCiudad = drCurrent["desCiudad"].ToString(),
                    desActivo = bool.Parse(drCurrent["activo"].ToString()) ? "Si" : "No"
                };

                listacli.Add(cliente);
            }
            return listacli;
        }

        public static bool AddEditCliente(Clientes cliente, int idCompany) //yjs 290719
        {
            try
            {
                int reg = 0;
                //var cActivo = cliente.activo ? "1" : "0";
                var cFecha = cliente.fechaAlta.ToString("yyyy-MM-dd HH:mm:ss") + ".000',";
                cadenaConexion = SelectCadena(idCompany);
                var lSucces = true;
                string sql = "spAddEditCliente " + cliente.idCliente + ",'" + cliente.descripcion + "','" + cliente.email
                    + "','" + cliente.mobile + "'," + cliente.idCiudad 
                    + ",'" + cFecha + cliente.activo;

                SqlConnection con = new SqlConnection(cadenaConexion);

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }

                return lSucces;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool deleteCliente(int idCliente, int idCompany) //yjs 29072019
        {
            int reg = 0;
            cadenaConexion = SelectCadena(idCompany);
            var lSucces = true;
            string sql = "delete from ClientesCrud where idCliente = " + idCliente;

            SqlConnection con = new SqlConnection(cadenaConexion);

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = CommandType.Text;
                con.Open();
                reg = cmd.ExecuteNonQuery();
                con.Close();
            }
            return lSucces;

        }

        public static List<Ciudades> GetCiudades(int idCompany) //yjs 300719
        {
            cadenaConexion = SelectCadena(idCompany);

            List<Ciudades> listaciudad = new List<Ciudades>();

            string sql = "select distinct * from Ciudades  ";

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaCiudad");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaCiudad"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                Ciudades tipocuenta = new Ciudades()
                {
                    idCiudad = Int32.Parse(drCurrent["idCiudad"].ToString()),
                    descripcion = drCurrent["descripcion"].ToString()
                };

                listaciudad.Add(tipocuenta);
            }
            return listaciudad;
        }
        #endregion

        #region Bills
        public static List<BillsView> GetBills(int idCompany) //yjs 010819
        {
            cadenaConexion = SelectCadena(idCompany);
            List<BillsView> listabills = new List<BillsView>();

            string sql = "select b.descripcion nombreCliente,a.*,replace(convert(NVARCHAR, a.dateDoc, 106), ' ', '/') fechaCorta " +
                " from bills a inner join clientesCrud b on a.idCliente = b.idCliente ";

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaBill");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaBill"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                BillsView bill = new BillsView()
                {
                    nombreCliente = (drCurrent["nombreCliente"].ToString()),
                    idBill = Int32.Parse(drCurrent["idBill"].ToString()),
                    billNo = drCurrent["billNo"].ToString(),
                    idCliente = Int32.Parse(drCurrent["idCliente"].ToString()),
                    pMethod = drCurrent["pMethod"].ToString(),
                    gTotal = float.Parse(drCurrent["gTotal"].ToString()),
                    dateDoc = DateTime.Parse(drCurrent["dateDoc"].ToString()),
                    fechaCorta = drCurrent["fechaCorta"].ToString()
                };

                listabills.Add(bill);
            }
            return listabills;
        }


        public static ResponseBill GetBill(int idBill, int idCompany) //yjs 010819
        {
            cadenaConexion = SelectCadena(idCompany);
            List<BillsView> listabill = new List<BillsView>();

            string sql = "select b.descripcion nombreCliente,a.*," +
                "replace(convert(NVARCHAR, a.dateDoc, 106), ' ', '/') fechaCorta  from bills a " +
                "inner join clientesCrud b on a.idCliente = b.idCliente where a.idBill =" + idBill;

            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dsResultado = new DataSet();
            adapter.Fill(dsResultado, "VistaBill");
            DataTable tblCliente;
            tblCliente = dsResultado.Tables["VistaBill"];

            foreach (DataRow drCurrent in tblCliente.Rows)
            {
                BillsView bill = new BillsView()
                {
                    nombreCliente = (drCurrent["nombreCliente"].ToString()),
                    idBill = Int32.Parse(drCurrent["idBill"].ToString()),
                    billNo = drCurrent["billNo"].ToString(),
                    idCliente = Int32.Parse(drCurrent["idCliente"].ToString()),
                    pMethod = drCurrent["pMethod"].ToString(),
                    gTotal = float.Parse(drCurrent["gTotal"].ToString()),
                    dateDoc = DateTime.Parse(drCurrent["dateDoc"].ToString()),
                    fechaCorta = drCurrent["fechaCorta"].ToString()
                };

                listabill.Add(bill);
            }

            List<BillsDetailView> detail = new List<BillsDetailView>();

            sql = "select a.billDetailId,a.billNo idBill,a.itemId,a.Quantity," +
                "b.name itemName,b.price Precio,b.price * a.Quantity Total ";
            sql = sql + "from billsDetail a ";
            sql = sql + "inner join items b on a.itemID = b.itemId ";
            sql = sql + "where a.billNo =" + idBill;

            SqlDataAdapter adapter02 = new SqlDataAdapter(sql, con);
            DataSet dsResultado02 = new DataSet();
            adapter02.Fill(dsResultado02, "VistaDetail");
            DataTable tblDetail;
            tblDetail = dsResultado02.Tables["VistaDetail"];

            foreach (DataRow drCurrent in tblDetail.Rows)
            {
                BillsDetailView deta = new BillsDetailView()
                {
                    billDetailId = Int32.Parse(drCurrent["billDetailId"].ToString()),
                    idBill = Int32.Parse(drCurrent["idBill"].ToString()),
                    itemId = Int32.Parse(drCurrent["itemId"].ToString()),
                    Quantity = Int32.Parse(drCurrent["Quantity"].ToString()),
                    itemName = drCurrent["itemName"].ToString(),
                    Precio = float.Parse(drCurrent["precio"].ToString()),
                    Total = float.Parse(drCurrent["Total"].ToString())

                };

                detail.Add(deta);
            }

            var response = new ResponseBill();
            response.bill = listabill;
            response.detail = detail;
            return response;
        }

        public static bool AddBill(Bills bill, int idCompany) //yjs 010819
        {
            try
            {
                int reg = 0;
                int nConsecutivo = 0;
                cadenaConexion = SelectCadena(idCompany);
                var lSucces = true;

                var cTotal = bill.gTotal + "";
                cTotal = cTotal.Replace(",", ".");

                string sql = "insert into bills (billNo,idCliente,pMethod,gTotal,dateDoc) output INSERTED.idBill values ('"
                    + bill.billNo + "'," + bill.idCliente + ",'" + bill.pMethod + "'," + cTotal + ",getdate())";

                SqlConnection con = new SqlConnection(cadenaConexion);

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    nConsecutivo = (int)cmd.ExecuteScalar();
                    con.Close();
                }

                foreach (var item in bill.billItems)
                {
                    sql = "insert into billsDetail (billNo,itemId,Quantity) values ("
                        + nConsecutivo + "," + item.itemId + "," + item.Quantity + ")";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        reg = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                return lSucces;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool UpdateBill(Bills bill, int idCompany) //yjs 010819
        {
            try
            {
                int reg = 0;
                cadenaConexion = SelectCadena(idCompany);
                var lSucces = true;

                var cTotal = bill.gTotal + "";
                cTotal = cTotal.Replace(",", ".");

                string sql = "update bills set idCliente = " + bill.idCliente +
                    ",pMethod = '" + bill.pMethod + "',gTotal = " + cTotal +
                    " where idBill = " + bill.idBill;

                SqlConnection con = new SqlConnection(cadenaConexion);

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }

                //delete
                sql = "delete from billsDetail where billNo= " + bill.idBill;

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }

                //end delete

                foreach (var item in bill.billItems)
                {
                    sql = "insert into billsDetail (billNo,itemId,Quantity) values ("
                        + bill.idBill + "," + item.itemId + "," + item.Quantity + ")";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        reg = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                return lSucces;

            }
            catch (Exception)
            {

                return false;
            }
        }


        public static bool deleteBill(int idBill, int idCompany) //yjs 010819
        {
            int reg = 0;
            cadenaConexion = SelectCadena(idCompany);
            var lSucces = true;
            string sql = "delete from billsDetail where billNo= " + idBill;
            SqlConnection con = new SqlConnection(cadenaConexion);

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = CommandType.Text;
                con.Open();
                reg = cmd.ExecuteNonQuery();
                con.Close();
            }

            sql = "delete from bills where idBill= " + idBill;

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = CommandType.Text;
                con.Open();
                reg = cmd.ExecuteNonQuery();
                con.Close();
            }
            return lSucces;

        }

        #endregion


        public static string SelectCadena(int idCompany)
        {
            string cRetorno = "";
            switch (idCompany)
            {
                case 1:
                    cRetorno = "data source=54.94.191.184,35863;initial catalog=discuy;user id=sa;password=2234;Connect Timeout=60";
                    break;
                case 2:
                    cRetorno = "data source=25.72.64.255;initial catalog=hardsell;user id=sa;password=hs2010;Connect Timeout=60";
                    break;
                case 3:
                    cRetorno = "data source=54.94.191.184,35863;initial catalog=moreno;user id=sa;password=2234;Connect Timeout=60";
                    break;
                case 4:
                    cRetorno = "data source=54.94.191.184,35863;initial catalog=electro;user id=sa;password=2234;Connect Timeout=60";
                    break;
                case 5:
                    cRetorno = "data source=18.228.126.65,35863;initial catalog=esekau;user id=sa;password=2234;Connect Timeout=60";
                    break;
                case 99:
                    cRetorno = "data source=54.94.191.184,35863;initial catalog=pruebas;user id=sa;password=2234;Connect Timeout=60";
                    break;
            }
            return cRetorno;
        }
    }
}