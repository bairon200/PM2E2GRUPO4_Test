using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM2E2GRUPO4.Modelo;
using PM2E2GRUPO4.VistasModelo;
using SignaturePad.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace PM2E2GRUPO4.Vsitas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewUpdate : ContentPage
    {
        public ViewUpdate()
        {
            InitializeComponent();



        }

        string Idusuario;
        string rutafoto;
        Stream image_;
        string estado = null;
        string iconRuta;

        public ViewUpdate(Modelo.Musuarios RegItem)
        {
            InitializeComponent();
            Idusuario = RegItem.Id_usuario;
            txtlatitud.Text = RegItem.latitud;
            txtlongitud.Text = RegItem.logintud;
            imagFirma.Source = RegItem.Icono;
            iconRuta = RegItem.Icono;

        }

        private void upFirma_Clicked(object sender, EventArgs e)
        {
            imagenCelular.IsVisible = true;
            imagFirma.IsVisible = false;
            estado = "actualizar";
        }


        private async Task InsertarUsuarios()
        {

            VMusuarios funcion = new VMusuarios();
            Musuarios parametros = new Musuarios();
            
            image_ = await imagenCelular.GetImageStreamAsync(SignatureImageFormat.Jpeg);


        }
        private async Task EditarFoto()
        {
            VMusuarios funcion = new VMusuarios();
            Musuarios parametros = new Musuarios();

            parametros.latitud = txtlatitud.Text;
            parametros.logintud = txtlongitud.Text;
            parametros.Icono = rutafoto;
            parametros.Id_usuario = Idusuario;

            await funcion.EditarFoto(parametros);
            await DisplayAlert("Listo", "Usuario Actualizado", "OK");


          

        }
        private async Task EliminarImagenUsuario()
        {
            VMusuarios funcion = new VMusuarios();            
            await funcion.EliminarImagen(Idusuario+".jpg");

            
        }

        private async Task SubirImagenesStore()
        {
            VMusuarios funcion = new VMusuarios();
            rutafoto = await funcion.SubirImagenesStorage(image_, Idusuario);
        }


        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (estado== "actualizar")
            {
                await InsertarUsuarios();
                await EliminarImagenUsuario();
                await SubirImagenesStore();


                await EditarFoto();
            }
            else if (estado==null)
            {

                VMusuarios funcion = new VMusuarios();
                Musuarios parametros = new Musuarios();

                parametros.latitud = txtlatitud.Text;
                parametros.logintud = txtlongitud.Text;
                parametros.Icono = iconRuta;
                parametros.Id_usuario = Idusuario;

                await funcion.EditarFoto(parametros);
                await DisplayAlert("Listo", "Usuario Actualizado", "OK");

            }           


            await Navigation.PopAsync();

        }


        private async void btnCordenadas_Clicked(object sender, EventArgs e)
        {
            var location = await Geolocation.GetLocationAsync();            if(location != null)            {                txtlatitud.Text = location.Latitude.ToString();                txtlongitud.Text = location.Longitude.ToString();            }

        }
    }
}