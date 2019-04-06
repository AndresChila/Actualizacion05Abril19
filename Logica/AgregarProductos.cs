using Datos;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Utilitarios;

namespace Logica
{    
    public class AgregarProductos
    {
        DataTable comp = new DataTable();
        DAOUsuario dAO = new DAOUsuario();
        Hashtable compIdioma = new Hashtable();
        string msj1, msj2, msj3, msj4, msj5, msj6, msj7, msj8, msj9, msj10, msj11, msj12, msj13, msj14, msj15, msj16;
        double precioTotal;
        int ultimito;

        public AgregarProductos(string idioma)
        {
            mensajesTrad(idioma, 1);
            msj1 = compIdioma["1"].ToString();
            msj2 = compIdioma["2"].ToString();
            msj3 = compIdioma["3"].ToString();
            msj4 = compIdioma["4"].ToString();
            msj5 = compIdioma["5"].ToString();
            msj6 = compIdioma["6"].ToString();
            msj7 = compIdioma["7"].ToString();
            msj8 = compIdioma["8"].ToString();
            msj9 = compIdioma["9"].ToString();
            msj10 = compIdioma["10"].ToString();
            msj11 = compIdioma["11"].ToString();
            msj12 = compIdioma["12"].ToString();
            msj13 = compIdioma["13"].ToString();
            msj14 = compIdioma["14"].ToString();
            msj15 = compIdioma["15"].ToString();
            msj16 = compIdioma["16"].ToString();
        }        

        public List<Producto> AnalizarGridView(string cantidad, string talla, string refPro, string sede, List<Producto> listaVenta)
        {            
            DAOUsuario dAO = new DAOUsuario();
            int cont = 0;
            
            Validaciones val = new Validaciones();
            if (val.validarVacio(talla) == true && val.validarVacio(refPro) == true)
            {
                if (val.validarVacio(cantidad) == true)
                {
                    if (val.validarNumeros(cantidad.ToString()) == true)
                    {
                        Producto producto = new Producto();
                        if (cantidad == "")
                        {
                            producto.Cantidad = 0;
                        }
                        else
                        {
                            producto.Cantidad = Convert.ToInt64(cantidad);
                        }
                        producto.Referencia = Convert.ToString(refPro);
                        producto.Talla = Convert.ToDouble(talla);

                        if (producto.Cantidad > 0)
                        {
                            bool vof;
                            cont++;
                            vof = dAO.validarCantidad(producto, sede);
                            if (vof == false)
                            { 
                                this.set_mensaje(msj1 + producto.Referencia + msj2 + producto.Talla + msj3);
                            }
                            else
                            {
                                producto.Precio = dAO.traePrecio(producto.Referencia, producto.Talla);
                                producto.ValorTotal = producto.Precio * producto.Cantidad;
                                producto.Idproducto = cont;
                                if (listaVenta == null)
                                {
                                    listaVenta = new List<Producto>();
                                    listaVenta.Add(producto);
                                }
                                else
                                {
                                    if (listaVenta.Contains(producto))
                                    {
                                        
                                        this.set_mensaje(msj4);
                                    }
                                    else
                                    {
                                        listaVenta.Add(producto);
                                        
                                        this.set_mensaje(msj5);
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (listaVenta == null)
                            {
                                listaVenta = new List<Producto>();
                                
                                this.set_mensaje(msj6);
                            }
                            else
                            {
                                return listaVenta;
                            }

                        }
                    }
                    else
                    {
                        
                        this.set_mensaje(msj7);
                    }
                }
                else
                {
                    
                    this.set_mensaje(msj8);

                    if (listaVenta == null)
                    {
                        listaVenta = new List<Producto>();
                        this.set_mensaje(msj8);
                    }
                    else
                    {
                        return listaVenta;
                    }
                }
            }
            else
            {
                if (listaVenta == null)
                {
                    listaVenta = new List<Producto>();
                    
                    this.set_mensaje(msj9);
                }
                else
                {
                    return listaVenta;
                }
            }
            
            if(cont == 0)
            {
                
                this.set_mensaje(msj10);
            }
            
            this.set_mensaje(msj11);
            return listaVenta;
}


        string msj;
        public void set_mensaje(string a)
        {
            msj = a;
        }

        public string get_mensaje()
        {
            return msj;
        }

        public string valorVenta(string val)
        {
            if(val != null)
            {
                return val;
            }
            
            return msj12;
        }
        public void actualizarVenta(Venta venta)
        {
            
            DAOUsuario dAO = new DAOUsuario();
            dAO.crearVenta(venta, JsonConvert.SerializeObject(venta.Producto));
        }
        public void actualizarInvent(string sede, Producto p)
        {
            DAOUsuario dAO = new DAOUsuario();

            dAO.actualizarInventario(p, Convert.ToString(sede));           

        }

        public string crearAbono(int idCliente, Abono venta)
        {
            DAOUsuario daop = new DAOUsuario();
            if (daop.validarAbono(idCliente) == 1)
            {
                
                return msj13;
            }
            else
            {
                DAOUsuario dAO = new DAOUsuario();

                dAO.crearAbono(venta, JsonConvert.SerializeObject(venta.Producto));
                
                return msj14;
            }
        }

        public bool botonBuscar(string referencia_, string talla_)
        {
            try
            {
                string referencia = Convert.ToString(referencia_);
                double talla = Convert.ToDouble(talla_);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public List<Producto> actualizar(string a , string b, string c, bool d)
        {
            List<Producto> listaVenta = new List<Producto>();
            if (botonBuscar(a, b) == false)
            {

            }
            else
            {
                Producto compara = new Producto();
                compara.Referencia = a;
                compara.Talla = Convert.ToDouble(b);
                LlenarGridViews llenara = new LlenarGridViews();
                DataTable aja = llenara.llenarGridViewVenta(c, d);                
                foreach (DataRow row in aja.Rows)
                {
                    Producto p = new Producto();
                    p.Referencia = Convert.ToString(row["referencia"]);
                    p.Talla = Convert.ToDouble(row["talla"]);
                    listaVenta.Add(p);
                }
                if (listaVenta.Contains(compara))
                {
                    listaVenta.Clear();
                    listaVenta.Add(compara);
                }
                else
                {

                }
            }
            return listaVenta;
        }

        public void BorrarDelGrid()
        {

        }

        public List<Producto> BorrarDelGrid(string comandoNombre, List<Producto> lista, string comandoArgument)
        {

            if (comandoNombre.Equals("Delete"))
            {
                List<Producto> pventa = new List<Producto>();
                pventa = lista;
                if (pventa.Count.Equals(0) != true)
                {
                    foreach (Producto p in pventa)
                    {
                        if (p.Idproducto == Convert.ToInt32(comandoArgument))
                        {
                            pventa.RemoveAt(Convert.ToInt32(comandoArgument) - 1);
                            lista = pventa;
                            return lista;
                        }
                        else
                        {

                            this.set_mensaje("no se what happen :(");
                        }
                    }
                }

            }
            return lista;
        }
        /*public Producto traerSeleccionado(string comando, string refer, string tallita)
        {
            DAOUsuario consul = new DAOUsuario();
            DataTable pro = new DataTable();
            Producto p = new Producto();
            if(comando == "Select")
            {
                pro = consul.traerPrecio(refer, double.Parse(tallita));
                for(int i =0; i< pro.Rows.Count; i++)
                {
                    
                }
            }
            return p;
        }*/

        public double sumarTotal(List<Producto> listaV)
        {
            foreach (Producto p in listaV)
            {
                precioTotal = precioTotal + p.ValorTotal;
            }
            return precioTotal;
        }

        public void paraInvent(List<Producto> prod, string sede)
        {
            List<Producto> refresh = new List<Producto>();
            refresh = (prod as List<Producto>);
            foreach (Producto p in refresh)
            {
                actualizarInvent(sede.ToString(), p);
            }
        }
        string response;
        public void validarValorVenta(string a, Venta venta)
        {
            if(a == null || a == "")
            {
                
                this.set_mensaje(msj15);
                response = "NuevaVenta.aspx";
            }
            else
            {
                
                this.set_mensaje(msj16);
                venta.Precio = Convert.ToDouble(a);
                response = "VistaFactura.aspx";
                actualizarVenta(venta);
            }
        }

        public string get_script()
        {
            string c = "alert('" + this.get_mensaje() + "');window.location.href = '" + response + "'; ";
            return c;
        }


        int kIdioma;
        public void mensajesTrad(string idioma, int constante)
        {

            DataTable idi = new DataTable();
            DAOUsuario dao = new DAOUsuario();
            idi = dao.traerIdioma();
            for (int i = 0; i < idi.Rows.Count; i++)
            {
                if (idi.Rows[i]["nombre"].ToString().ToLower() == idioma.ToLower())
                {
                    kIdioma = int.Parse(idi.Rows[i]["id"].ToString());
                }
            }
            comp = dAO.traerMensajes(kIdioma, constante);
            for (int i = 0; i < comp.Rows.Count; i++)
            {
                compIdioma.Add(comp.Rows[i]["msj"].ToString(), comp.Rows[i]["texto"].ToString());
            }
        }
        public int getUltimito()
        {
            DataTable ul = new DataTable();
            ul = dAO.verUltimoId3();
            ultimito = int.Parse(ul.Rows[0]["f_verultimoid3"].ToString());
            return ultimito;
        }
    }
}