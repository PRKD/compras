using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using nmExcel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace Costes_Logisticos_Quality
{
    public partial class FrmPrincipal : Form
    {
        DataTable dt=new DataTable();
        public FrmPrincipal()
        {
            InitializeComponent();
            //qC600DataSet1.
            //QC600DataSet1.
            //QC600DataSet.ALBARAN_CABETableAdapter 
            //ALBARAN_CABETableAdapter
            //qC600DataSet1.c
           
        }

        private void consulta_sql(string dia1,string dia2, string agencia)
        {
            try
            {
                dt = new DataTable();
                SqlConnection conexion = new SqlConnection("Data Source=192.168.1.195\\sqlserver2008;Initial Catalog=QC600;Persist Security Info=True;User ID=dso;Password=dsodsodso");
                SqlCommand cmd = new SqlCommand();
                DataTable dtp = new DataTable();
                SqlDataReader reader;

                //Crear DataTable que voy a rellenar para mostrar en DatagridView
                DataTable datos = new DataTable();

                datos.Columns.Add("Cliente", typeof(String));
                datos.Columns.Add("Nº Pedido", typeof(String));
                datos.Columns.Add("Nº Albaran", typeof(String));
                datos.Columns.Add("Nombre Cliente", typeof(String));
                datos.Columns.Add("Direccion", typeof(String));
                datos.Columns.Add("Cod. Postal", typeof(String));
                datos.Columns.Add("Poblacion", typeof(String));
                datos.Columns.Add("Nº Palets", typeof(String));
                datos.Columns.Add("KG", typeof(String));
                datos.Columns.Add("Nº Ruta", typeof(String));
                datos.Columns.Add("Agencia", typeof(String));
                datos.Columns.Add("Fecha Albaran", typeof(String));
                datos.Columns.Add("Observaciones", typeof(String));

                //Consulta SQL
                string sql = "";
                if (agencia.Length > 0)
                {
                    sql = @"SELECT DISTINCT 
                      ALBARAN_CABE.Empresa, ALBARAN_CABE.[Nº Albarán],  Convert(varchar,ALBARAN_CABE.[Fecha Emisión],103), CLIENTE.Cliente, CLIENTE.[Nombre envio] AS [Nombre Cliente], 
                      CLIENTE.[Dirección envio] AS Direccion, CLIENTE.[Cod Postal envio] AS CPostal, CLIENTE.[Población envio] AS Poblacion, 
                      CASE ARTICULO.[Uds Venta] WHEN 'Ud' THEN ALBARAN_LIN.Cantidad * ARTICULO.[Factor(Kg/Ud)] ELSE ALBARAN_LIN.Cantidad END AS PESO, 
                      ALBARAN_LIN.Artículo, ALBARAN_LIN.[Nº linea Albarán], ALBARAN_LIN.Cantidad, ARTICULO.[Factor(Kg/Ud)], ALBARAN_CABE.Ruta, ALBARAN_CABE.Cerrado, 
                      ALBARAN_CABE.[Albarán Impreso], ALBARAN_CABE.Observaciones, ALBARAN_LIN.[Nº Pedido], ALBARAN_CABE.Ruta ,RUTA.Descripción
FROM         ARTICULO RIGHT OUTER JOIN
                      ALBARAN_LIN RIGHT OUTER JOIN
                      ALBARAN_CABE INNER JOIN
                      RUTA ON ALBARAN_CABE.Ruta = RUTA.Ruta ON ALBARAN_LIN.Serie = ALBARAN_CABE.Serie AND ALBARAN_LIN.Empresa = ALBARAN_CABE.Empresa AND 
                      ALBARAN_LIN.Año = ALBARAN_CABE.Año AND ALBARAN_LIN.[Nº Albarán] = ALBARAN_CABE.[Nº Albarán] ON 
                      ARTICULO.Artículo = ALBARAN_LIN.Artículo LEFT OUTER JOIN
                      CLIENTE ON ALBARAN_CABE.[Código Cliente] = CLIENTE.Cliente
WHERE       (ALBARAN_CABE.Ruta  = " + agencia + ") AND (ALBARAN_CABE.[Fecha Emisión] >=CONVERT(datetime, '" + dia1 + @"', 103))AND (ALBARAN_CABE.[Fecha Emisión] <=CONVERT(datetime, '" + dia2 + @"', 103))";
                }
                else {
                    sql = @"SELECT DISTINCT 
                      ALBARAN_CABE.Empresa, ALBARAN_CABE.[Nº Albarán],  Convert(varchar,ALBARAN_CABE.[Fecha Emisión],103), CLIENTE.Cliente, CLIENTE.[Nombre envio] AS [Nombre Cliente], 
                      CLIENTE.[Dirección envio] AS Direccion, CLIENTE.[Cod Postal envio] AS CPostal, CLIENTE.[Población envio] AS Poblacion, 
                      CASE ARTICULO.[Uds Venta] WHEN 'Ud' THEN ALBARAN_LIN.Cantidad * ARTICULO.[Factor(Kg/Ud)] ELSE ALBARAN_LIN.Cantidad END AS PESO, 
                      ALBARAN_LIN.Artículo, ALBARAN_LIN.[Nº linea Albarán], ALBARAN_LIN.Cantidad, ARTICULO.[Factor(Kg/Ud)], ALBARAN_CABE.Ruta, ALBARAN_CABE.Cerrado, 
                      ALBARAN_CABE.[Albarán Impreso], ALBARAN_CABE.Observaciones, ALBARAN_LIN.[Nº Pedido], ALBARAN_CABE.Ruta ,RUTA.Descripción
FROM         ARTICULO RIGHT OUTER JOIN
                      ALBARAN_LIN RIGHT OUTER JOIN
                      ALBARAN_CABE INNER JOIN
                      RUTA ON ALBARAN_CABE.Ruta = RUTA.Ruta ON ALBARAN_LIN.Serie = ALBARAN_CABE.Serie AND ALBARAN_LIN.Empresa = ALBARAN_CABE.Empresa AND 
                      ALBARAN_LIN.Año = ALBARAN_CABE.Año AND ALBARAN_LIN.[Nº Albarán] = ALBARAN_CABE.[Nº Albarán] ON 
                      ARTICULO.Artículo = ALBARAN_LIN.Artículo LEFT OUTER JOIN
                      CLIENTE ON ALBARAN_CABE.[Código Cliente] = CLIENTE.Cliente
WHERE        (ALBARAN_CABE.[Fecha Emisión] >=CONVERT(datetime, '" + dia1 + @"', 103))AND (ALBARAN_CABE.[Fecha Emisión] <=CONVERT(datetime, '" + dia2 + @"', 103))";
                }
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion;
                conexion.Open();
                reader = cmd.ExecuteReader();
                dt.Load(reader);

                conexion.Close();
                bool flag = true;

                var Consulta = (from DataRow nclient in dt.AsEnumerable()
                                select new
                                {
                                    nClient = nclient[3],
                                    nempresa = nclient[0],
                                    //pedido = nclient[8],
                                    albaran = nclient[1],
                                    cliente = nclient[4],
                                    direccion = nclient[5],
                                    cpost = nclient[6],
                                    poblacion = nclient[7],
                                    fecha = nclient[2],
                                    npedidolin = nclient[17],
                                    nruta = nclient[18],
                                    ruta=nclient[19]
                                }).Distinct();
                
                int i = 0;
                foreach (var con in Consulta)
                {

                    double peso = (from DataRow npeso in dt.AsEnumerable() where (int)npeso[1] == (int)con.albaran select (double)npeso[8]).Sum();
                    double Bultos = (from DataRow nBultos in dt.AsEnumerable() where (int)nBultos[3] == (int)con.nClient && ((int)nBultos[9] == 6645 || (int)nBultos[9] == 6644 || (int)nBultos[9] == 6413 || (int)nBultos[9] == 6705) select (double)nBultos[11]).Sum();
                    string pedido = "";
                    DataTable dtnumero = new DataTable();
                    
                    if (Convert.ToInt32(con.npedidolin) > 0)
                    {
                        string sqlpedido = @"select [PEDIDO_CABE CANCEL].[NºPedido Cliente] from [PEDIDO_CABE CANCEL] where [PEDIDO_CABE CANCEL].[Nº Pedido]=" + con.npedidolin + "and [PEDIDO_CABE CANCEL].[Año]=2013 and [PEDIDO_CABE CANCEL].[Empresa]=" + con.nempresa;
                        cmd.CommandText = sqlpedido;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conexion;
                        conexion.Open();
                        reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dtnumero.Load(reader);
                            flag = false;
                        }
                        else
                        {
                            conexion.Close();
                            sqlpedido = @"select  [QC600].[dbo].[PEDIDO_CABE].[NºPedido Cliente] from  [QC600].[dbo].[PEDIDO_CABE] where  [QC600].[dbo].[PEDIDO_CABE].[Nº Pedido]=" + con.npedidolin + "and  [QC600].[dbo].[PEDIDO_CABE].[Año]=2013 and  [QC600].[dbo].[PEDIDO_CABE].[Empresa]=" + con.nempresa;
                            cmd.CommandText = sqlpedido;
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = conexion;
                            conexion.Open();
                            reader = cmd.ExecuteReader();;
                            if (reader.HasRows)
                            {
                                dtnumero.Load(reader);
                                flag = false;
                            }
                        }

                        conexion.Close();

                    }
                    try
                    {
                        if (dtnumero.Rows.Count > 0)
                            pedido = dtnumero.Rows[0].ItemArray[0].ToString();
                    }
                    catch (Exception e)
                    { MessageBox.Show(e.Message); }
                    
                    i++;
                   if (pedido != "0" && flag != true)
                    {
                        flag = true;
                        datos.Rows.Add(con.nClient, pedido, con.albaran, con.cliente, con.direccion, con.cpost, con.poblacion, Bultos, peso, con.nruta, con.ruta, con.fecha, "");
                    }                }
                //Muestro el resultado en un GridView 
                if (datos.Rows.Count > 0)
                {
                    DataTable dt_fin = datos.Clone();
                    var data_p = (from x in datos.AsEnumerable() where x[1].ToString() != "0" select x).Distinct();
                    foreach (var elemento in data_p)
                        dt_fin.ImportRow(elemento);


                    dataGridView1.DataSource = dt_fin;
                }
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message);
            }
        }

        private void consulta_sql_pedidos(string dia1, string dia2)
        {
            try
            {
                dt = new DataTable();
                SqlConnection conexion = new SqlConnection("Data Source=192.168.1.195\\sqlserver2008;Initial Catalog=QC600;Persist Security Info=True;User ID=dso;Password=dsodsodso");
                SqlCommand cmd = new SqlCommand();
                DataTable dtp = new DataTable();
                SqlDataReader reader;

                //Crear DataTable que voy a rellenar para mostrar en DatagridView
                DataTable datos = new DataTable();
                datos.Columns.Add("Nº Pedido", typeof(String));
                datos.Columns.Add("Fecha Pedido", typeof(String));
                datos.Columns.Add("Fecha Entrega", typeof(String));
                datos.Columns.Add("Cod. Cliente", typeof(String));
                datos.Columns.Add("Nombre Cliente", typeof(String));
                datos.Columns.Add("Empresa", typeof(String));
                datos.Columns.Add("Cod. Producto", typeof(String));
                datos.Columns.Add("Nombre Producto", typeof(String));
                datos.Columns.Add("Unidad de Medida", typeof(String));

                datos.Columns.Add("Cantidad Pedida ", typeof(String));
                datos.Columns.Add("Cantidad entregada", typeof(String));
                datos.Columns.Add("Diferencia", typeof(String));
                datos.Columns.Add("Cod. Comercial asignado", typeof(String));
                datos.Columns.Add("Comercial Asignado", typeof(String));
                datos.Columns.Add("Observaciones", typeof(String));
                datos.Columns.Add("Tipo Falta", typeof(String));
               // datos.Columns.Add("Observaciones", typeof(String));

                //Consulta SQL
                string sql = @"SELECT DISTINCT 
                      CONVERT(varchar, PEDIDO_CABE.[Fecha Pedido], 103) AS [Fecha Pedido], CONVERT(varchar, PEDIDO_CABE.[Fecha Entrega], 103) AS [Fecha Entrega], 
                      CLIENTE.Cliente, CLIENTE.[Nombre envio] AS [Nombre Cliente], PEDIDO_CABE.Empresa, PEDIDO_CABE.[Nº Pedido], PEDIDO_LIN.Artículo, ARTICULO.Descripción,ARTICULO.[Uds Venta], 
                      PEDIDO_LIN.[Cant Pedida en Uds] , 
                      PEDIDO_LIN.[Cant Recibida en Uds],PEDIDO_LIN.[Cant Pedida en Uds] -case when PEDIDO_LIN.[Cant Recibida en Uds] is not null then PEDIDO_LIN.[Cant Recibida en Uds]else '0' end as [Diferencia],
                      CLIENTE.[Cuadro comisiones] AS Comercial, [CUADRO COMISIONES].Descripción AS [nombre Comercial], PEDIDO_CABE.Observaciones
FROM         [CUADRO COMISIONES] INNER JOIN
                      CLIENTE ON [CUADRO COMISIONES].Cuadro = CLIENTE.[Cuadro comisiones] RIGHT OUTER JOIN
                      ARTICULO RIGHT OUTER JOIN
                      PEDIDO_LIN RIGHT OUTER JOIN
                      PEDIDO_CABE INNER JOIN
                      RUTA ON PEDIDO_CABE.Ruta = RUTA.Ruta ON PEDIDO_LIN.[Nº Pedido] = PEDIDO_CABE.[Nº Pedido] AND PEDIDO_LIN.Empresa = PEDIDO_CABE.Empresa AND 
                      PEDIDO_LIN.Año = PEDIDO_CABE.Año ON ARTICULO.Artículo = PEDIDO_LIN.Artículo ON CLIENTE.Cliente = PEDIDO_CABE.[Código C/P]
WHERE     (PEDIDO_CABE.[Fecha Entrega] >= CONVERT(datetime,'" + dia1 + @"', 103)) AND (PEDIDO_CABE.[Fecha Entrega] <= CONVERT(datetime,'" + dia2 + @"', 103)) and  Cliente is not null and (PEDIDO_LIN.[Cant Pedida en Uds]<>PEDIDO_LIN.[Cant Recibida en Uds] OR PEDIDO_LIN.[Cant Recibida en Uds]is null OR PEDIDO_LIN.[Cant Pedida en Uds] is null)";

           
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion;
                conexion.Open();
                reader = cmd.ExecuteReader();
                dt.Load(reader);

                conexion.Close();
                bool flag = true;

                var Consulta = (from DataRow nclient in dt.AsEnumerable()
                                select new
                                {
                                    Fechaped = nclient[0],
                                    fechaentr = nclient[1],
                                    cliente = nclient[2],
                                    nombreCli=nclient[3],
                                    empresa=nclient[4],
                                    npedido=nclient[5],
                                    narticulo=nclient[6],
                                    ndescrip=nclient[7],
                                    unidadVent=nclient[8],
                                    ncantidaped=nclient[9],
                                    ncatidadentre=nclient[10],
                                    diferencia=nclient[11],
                                   
                                    ncomercial=nclient[12],
                                    comercial=nclient[13],
                                    observa=nclient[14]


                                }).Distinct();

                int i = 0;
                foreach (var dr in Consulta.AsEnumerable())
                {
                    datos.Rows.Add(dr.npedido,dr.Fechaped, dr.fechaentr, dr.cliente, dr.nombreCli, dr.empresa, dr.narticulo, dr.ndescrip, dr.unidadVent, dr.ncantidaped, dr.ncatidadentre,dr.diferencia, dr.ncomercial, dr.comercial, dr.observa,"");
                }
                //datos.Rows.Add(Consulta.
                dataGridView1.DataSource = datos;
               
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message);
            }
        }
        private void consulta_sql_Articulo(string dia1, string dia2, string empresa, string articulo)
        {
            try
            {
                SqlConnection conexion = new SqlConnection("Data Source=192.168.1.195\\sqlserver2008;Initial Catalog=QC600;Persist Security Info=True;User ID=dso;Password=dsodsodso");
                SqlCommand cmd = new SqlCommand();
                DataTable dtp = new DataTable();
                SqlDataReader reader;
                string sql = "";
               
                dataGridView1.DataSource = null;


                if (articulo.Length > 0)
                {

                    sql = @"SELECT RECEPCION_CABE.[Nº Albarán], 
RECEPCION_LIN.[Nº linea Albarán], 
RECEPCION_CABE.[Nº Alb Proveedor], 
RECEPCION_CABE.[Fecha Recepción], 
[TIPO IVA].iva AS iva_articulo, 
RECEPCION_LIN.Artículo, 
RECEPCION_LIN.CampoAuxText4 AS Lote,
RECEPCION_LIN.Cantidad, 
ARTICULO.[Uds Compra], 
RECEPCION_LIN.[Precio Compra], 
RECEPCION_LIN.Cantidad* RECEPCION_LIN.[Precio Compra] as [Precio],
RECEPCION_LIN.Cajas, 
ARTICULO.Descripción, 
PROVEEDOR.Nombre as [Nombre Provedor], 
PROVEEDOR.Proveedor, 
EMPRESA.Nombre
FROM (((((PROVEEDOR RIGHT JOIN RECEPCION_CABE ON PROVEEDOR.Proveedor = RECEPCION_CABE.[Código Proveedor]) INNER JOIN ((ARTICULO INNER JOIN RECEPCION_LIN ON ARTICULO.Artículo = RECEPCION_LIN.Artículo) INNER JOIN [TIPO IVA] ON (ARTICULO.[Tipo Iva] = [TIPO IVA].[Tipo Iva]) AND (ARTICULO.[Tipo Iva] = [TIPO IVA].[Tipo Iva])) ON (RECEPCION_CABE.[Nº Albarán] = RECEPCION_LIN.[Nº Albarán]) AND (RECEPCION_CABE.Serie = RECEPCION_LIN.Serie) AND (RECEPCION_CABE.Empresa = RECEPCION_LIN.Empresa) AND (RECEPCION_CABE.Año = RECEPCION_LIN.Año)) LEFT JOIN [TIPO IVA] AS [TIPO IVA_1] ON PROVEEDOR.[Iva Agrario] = [TIPO IVA_1].[Tipo Iva]) LEFT JOIN [FORMA PAGO] ON PROVEEDOR.[Forma Pago] = [FORMA PAGO].[Forma Pago]) LEFT JOIN EMPRESA ON RECEPCION_CABE.Empresa = EMPRESA.Empresa) LEFT JOIN SILO ON RECEPCION_LIN.SSCCGenerado = SILO.SSCCSilo
where RECEPCION_CABE.[Fecha Recepción]>=CONVERT(datetime, '" + dia1 + @"', 103)and RECEPCION_CABE.[Fecha Recepción]<=CONVERT(datetime, '" + dia2 + @"', 103) and RECEPCION_CABE.Empresa=" + empresa + " and RECEPCION_LIN.Artículo= " + articulo + @"
ORDER BY RECEPCION_CABE.Año, RECEPCION_CABE.Empresa, RECEPCION_CABE.Serie, RECEPCION_CABE.[Nº Albarán], RECEPCION_LIN.Artículo;";
                }
                else
                {
                    sql = @"SELECT RECEPCION_CABE.[Nº Albarán], 
RECEPCION_LIN.[Nº linea Albarán], 

RECEPCION_CABE.[Nº Alb Proveedor], 
RECEPCION_CABE.[Fecha Recepción], 
[TIPO IVA].iva AS iva_articulo, 
RECEPCION_LIN.Artículo, 
RECEPCION_LIN.CampoAuxText4 AS Lote,
RECEPCION_LIN.Cantidad, 
ARTICULO.[Uds Compra], 
RECEPCION_LIN.[Precio Compra], 
RECEPCION_LIN.Cantidad* RECEPCION_LIN.[Precio Compra] as [Precio],
RECEPCION_LIN.Cajas, 
ARTICULO.Descripción, 
PROVEEDOR.Nombre as [Nombre Provedor], 
PROVEEDOR.Proveedor, 
EMPRESA.Nombre
FROM (((((PROVEEDOR RIGHT JOIN RECEPCION_CABE ON PROVEEDOR.Proveedor = RECEPCION_CABE.[Código Proveedor]) INNER JOIN ((ARTICULO INNER JOIN RECEPCION_LIN ON ARTICULO.Artículo = RECEPCION_LIN.Artículo) INNER JOIN [TIPO IVA] ON (ARTICULO.[Tipo Iva] = [TIPO IVA].[Tipo Iva]) AND (ARTICULO.[Tipo Iva] = [TIPO IVA].[Tipo Iva])) ON (RECEPCION_CABE.[Nº Albarán] = RECEPCION_LIN.[Nº Albarán]) AND (RECEPCION_CABE.Serie = RECEPCION_LIN.Serie) AND (RECEPCION_CABE.Empresa = RECEPCION_LIN.Empresa) AND (RECEPCION_CABE.Año = RECEPCION_LIN.Año)) LEFT JOIN [TIPO IVA] AS [TIPO IVA_1] ON PROVEEDOR.[Iva Agrario] = [TIPO IVA_1].[Tipo Iva]) LEFT JOIN [FORMA PAGO] ON PROVEEDOR.[Forma Pago] = [FORMA PAGO].[Forma Pago]) LEFT JOIN EMPRESA ON RECEPCION_CABE.Empresa = EMPRESA.Empresa) LEFT JOIN SILO ON RECEPCION_LIN.SSCCGenerado = SILO.SSCCSilo
where RECEPCION_CABE.[Fecha Recepción]>=CONVERT(datetime, '" + dia1 + @"', 103)and RECEPCION_CABE.[Fecha Recepción]<=CONVERT(datetime, '" + dia2 + @"', 103) and RECEPCION_CABE.Empresa=" + empresa +  @"
ORDER BY RECEPCION_CABE.Año, RECEPCION_CABE.Empresa, RECEPCION_CABE.Serie, RECEPCION_CABE.[Nº Albarán], RECEPCION_LIN.Artículo;";
                }
                // conexion.Open();

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion;
                conexion.Open();
                reader = cmd.ExecuteReader();
                dt.Load(reader);

                conexion.Close();
                dataGridView1.DataSource = dt;
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message);
            }
         }
        private void consulta_sql_provedor(string dia1, string dia2, string empresa, string proveedor)
        {
            try
            {
                SqlConnection conexion = new SqlConnection("Data Source=192.168.1.195\\sqlserver2008;Initial Catalog=QC600;Persist Security Info=True;User ID=dso;Password=dsodsodso");
                SqlCommand cmd = new SqlCommand();
                DataTable dtp = new DataTable();
                SqlDataReader reader;
                string sql = "";
                DataTable dtnumero = new DataTable();
                dataGridView1.DataSource = dtnumero;


                if (proveedor.Length > 0)
                {

                    sql = @"SELECT RECEPCION_CABE.[Nº Albarán], 
RECEPCION_LIN.[Nº linea Albarán], 
RECEPCION_CABE.[Nº Alb Proveedor], 
RECEPCION_CABE.[Fecha Recepción], 
[TIPO IVA].iva AS iva_articulo, 
RECEPCION_LIN.Artículo, 
RECEPCION_LIN.CampoAuxText4 AS Lote,
RECEPCION_LIN.Cantidad, 
ARTICULO.[Uds Compra], 
RECEPCION_LIN.[Precio Compra], 
RECEPCION_LIN.Cantidad* RECEPCION_LIN.[Precio Compra] as [Precio],
RECEPCION_LIN.Cajas, 
ARTICULO.Descripción, 
PROVEEDOR.Nombre as [Nombre Provedor], 
PROVEEDOR.Proveedor, 
EMPRESA.Nombre
FROM (((((PROVEEDOR RIGHT JOIN RECEPCION_CABE ON PROVEEDOR.Proveedor = RECEPCION_CABE.[Código Proveedor]) INNER JOIN ((ARTICULO INNER JOIN RECEPCION_LIN ON ARTICULO.Artículo = RECEPCION_LIN.Artículo) INNER JOIN [TIPO IVA] ON (ARTICULO.[Tipo Iva] = [TIPO IVA].[Tipo Iva]) AND (ARTICULO.[Tipo Iva] = [TIPO IVA].[Tipo Iva])) ON (RECEPCION_CABE.[Nº Albarán] = RECEPCION_LIN.[Nº Albarán]) AND (RECEPCION_CABE.Serie = RECEPCION_LIN.Serie) AND (RECEPCION_CABE.Empresa = RECEPCION_LIN.Empresa) AND (RECEPCION_CABE.Año = RECEPCION_LIN.Año)) LEFT JOIN [TIPO IVA] AS [TIPO IVA_1] ON PROVEEDOR.[Iva Agrario] = [TIPO IVA_1].[Tipo Iva]) LEFT JOIN [FORMA PAGO] ON PROVEEDOR.[Forma Pago] = [FORMA PAGO].[Forma Pago]) LEFT JOIN EMPRESA ON RECEPCION_CABE.Empresa = EMPRESA.Empresa) LEFT JOIN SILO ON RECEPCION_LIN.SSCCGenerado = SILO.SSCCSilo
where RECEPCION_CABE.[Fecha Recepción]>=CONVERT(datetime, '" + dia1 + @"', 103)and RECEPCION_CABE.[Fecha Recepción]<=CONVERT(datetime, '" + dia2 + @"', 103) and RECEPCION_CABE.Empresa=" + empresa + " and RECEPCION_CABE.[Código Proveedor]= " + proveedor + @"
ORDER BY RECEPCION_CABE.Año, RECEPCION_CABE.Empresa, RECEPCION_CABE.Serie, RECEPCION_CABE.[Nº Albarán], RECEPCION_LIN.Artículo;";
                }
                else
                {
                    sql = @"SELECT RECEPCION_CABE.[Nº Albarán], 
RECEPCION_LIN.[Nº linea Albarán], 

RECEPCION_CABE.[Nº Alb Proveedor], 
RECEPCION_CABE.[Fecha Recepción], 
[TIPO IVA].iva AS iva_articulo, 
RECEPCION_LIN.Artículo, 
RECEPCION_LIN.CampoAuxText4 AS Lote,
RECEPCION_LIN.Cantidad, 
ARTICULO.[Uds Compra], 
RECEPCION_LIN.[Precio Compra], 
RECEPCION_LIN.Cantidad* RECEPCION_LIN.[Precio Compra] as [Precio],
RECEPCION_LIN.Cajas, 
ARTICULO.Descripción, 
PROVEEDOR.Nombre as [Nombre Provedor], 
PROVEEDOR.Proveedor, 
EMPRESA.Nombre
FROM (((((PROVEEDOR RIGHT JOIN RECEPCION_CABE ON PROVEEDOR.Proveedor = RECEPCION_CABE.[Código Proveedor]) INNER JOIN ((ARTICULO INNER JOIN RECEPCION_LIN ON ARTICULO.Artículo = RECEPCION_LIN.Artículo) INNER JOIN [TIPO IVA] ON (ARTICULO.[Tipo Iva] = [TIPO IVA].[Tipo Iva]) AND (ARTICULO.[Tipo Iva] = [TIPO IVA].[Tipo Iva])) ON (RECEPCION_CABE.[Nº Albarán] = RECEPCION_LIN.[Nº Albarán]) AND (RECEPCION_CABE.Serie = RECEPCION_LIN.Serie) AND (RECEPCION_CABE.Empresa = RECEPCION_LIN.Empresa) AND (RECEPCION_CABE.Año = RECEPCION_LIN.Año)) LEFT JOIN [TIPO IVA] AS [TIPO IVA_1] ON PROVEEDOR.[Iva Agrario] = [TIPO IVA_1].[Tipo Iva]) LEFT JOIN [FORMA PAGO] ON PROVEEDOR.[Forma Pago] = [FORMA PAGO].[Forma Pago]) LEFT JOIN EMPRESA ON RECEPCION_CABE.Empresa = EMPRESA.Empresa) LEFT JOIN SILO ON RECEPCION_LIN.SSCCGenerado = SILO.SSCCSilo
where RECEPCION_CABE.[Fecha Recepción]>=CONVERT(datetime, '" + dia1 + @"', 103)and RECEPCION_CABE.[Fecha Recepción]<=CONVERT(datetime, '" + dia2 + @"', 103) and RECEPCION_CABE.Empresa=" + empresa + @"
ORDER BY RECEPCION_CABE.Año, RECEPCION_CABE.Empresa, RECEPCION_CABE.Serie, RECEPCION_CABE.[Nº Albarán], RECEPCION_LIN.Artículo;";
                }
                // conexion.Open();

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion;
                conexion.Open();
                reader = cmd.ExecuteReader();
                dt.Load(reader);

                conexion.Close();
                dataGridView1.DataSource = dt;
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message);
            }
        }
 //       private void consulta_sql(string dia1, string dia2, string agencia, string empresa) { }
                

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            nmExcel.ApplicationClass ExcelApp = new nmExcel.ApplicationClass();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 12;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                DataGridViewRow Fila = dataGridView1.Rows[i];
                for (int j = 0; j < Fila.Cells.Count; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = Fila.Cells[j].Value;
                }
            }
            // ---------- cuadro de dialogo para Guardar
            SaveFileDialog CuadroDialogo = new SaveFileDialog();
            CuadroDialogo.DefaultExt = "xls";
            CuadroDialogo.Filter = "xls file(*.xls)|*.xls";
            CuadroDialogo.AddExtension = true;
            CuadroDialogo.RestoreDirectory = true;
            CuadroDialogo.Title = "Guardar";
            CuadroDialogo.InitialDirectory = @"c:\";
            if (CuadroDialogo.ShowDialog() == DialogResult.OK)
            {
                ExcelApp.ActiveWorkbook.SaveCopyAs(CuadroDialogo.FileName);
                ExcelApp.ActiveWorkbook.Saved = true;
                CuadroDialogo.Dispose();
                CuadroDialogo = null;
                ExcelApp.Quit();
            }
            else
            {
                MessageBox.Show("No se pudo guardar Datos .. ");
            }
        }

        private void guardarEnExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog CuadroDialogo = new SaveFileDialog();
            CuadroDialogo.DefaultExt = "xls";
            CuadroDialogo.Filter = "xls file(*.xls)|*.xls";
            CuadroDialogo.AddExtension = true;
            CuadroDialogo.RestoreDirectory = true;
            CuadroDialogo.Title = "Guardar";
            CuadroDialogo.InitialDirectory = @"c:\";
            nmExcel.ApplicationClass ExcelApp = new nmExcel.ApplicationClass();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 12;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                DataGridViewRow Fila = dataGridView1.Rows[i];
                for (int j = 0; j < Fila.Cells.Count; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = Fila.Cells[j].Value;
                }
            }
            if (CuadroDialogo.ShowDialog() == DialogResult.OK)
            {
                ExcelApp.ActiveWorkbook.SaveCopyAs(CuadroDialogo.FileName);
                ExcelApp.ActiveWorkbook.Saved = true;
                CuadroDialogo.Dispose();
                CuadroDialogo = null;
                ExcelApp.Quit();
            }
            else
            {
                MessageBox.Show("No se pudo guardar Datos .. ");
            }
        }



        private void informePorFechasAgenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProvedorfechas dialogo_agencia_fecha = new FrmProvedorfechas();
            DialogResult result = dialogo_agencia_fecha.ShowDialog();
            if (result == DialogResult.OK)
            {

                consulta_sql_provedor(dialogo_agencia_fecha.fecha1, dialogo_agencia_fecha.fecha2, dialogo_agencia_fecha.empresa, dialogo_agencia_fecha.proveedor);
            }
        }



        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void informeArticuloComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmComprArticulo dialogo_compras_articulo = new frmComprArticulo();
            DialogResult result = dialogo_compras_articulo.ShowDialog();
            if (result == DialogResult.OK)
            {

                consulta_sql_Articulo(dialogo_compras_articulo.fecha1, dialogo_compras_articulo.fecha2, dialogo_compras_articulo.empresa, dialogo_compras_articulo.Articulo);
            }
        }

        private void informeRutasAgenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fecha dialogo_fechas = new Fecha();
            DialogResult result = dialogo_fechas.ShowDialog();
            if (result == DialogResult.OK)
            {
                consulta_sql(dialogo_fechas.fecha1, dialogo_fechas.fecha2, "");
            }
        }

        private void informePedidosFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fecha dialogo_fechas = new Fecha();
            DialogResult result = dialogo_fechas.ShowDialog();
            if (result == DialogResult.OK)
            {
                consulta_sql_pedidos(dialogo_fechas.fecha1, dialogo_fechas.fecha2);
            }
        }
    }
}
