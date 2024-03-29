
using System;
using System.Windows.Forms;

namespace  PeakCanInitializationExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PcanChannel channel = PcanChannel.Usb01;
            PcanStatus result = Api.Initialize(channel, Bitrate.Pcan500);

            if (result != PcanStatus.OK)
            {
                // An error occurred
                Api.GetErrorText(result, out var errorText);
                MessageBox.Show(errorText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // A success message is shown
                MessageBox.Show($"The hardware represented by the handle {channel} was successfully initialized.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // The connection to the hardware is finalized when it is no longer needed
                result = Api.Uninitialize(channel);
                if (result != PcanStatus.OK)
                {
                    // An error occurred
                    Api.GetErrorText(result, out var errorText);
                    MessageBox.Show(errorText, "Error Finalizing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"The hardware represented by the handle {channel} was successfully finalized.", "Finalized Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

    // Bu sýnýflar ve enumlar Api, PcanChannel, Bitrate, PcanStatus gibi yapýlarýn tanýmlanmasý gerekecektir.
    // Örneðin:
    public static class Api
    {
        public static PcanStatus Initialize(PcanChannel channel, Bitrate bitrate)
        {
            // Initialize iþlemleri...
            return PcanStatus.OK; // Gerçek duruma göre deðiþtir
        }

        public static PcanStatus Uninitialize(PcanChannel channel)
        {
            // Uninitialize iþlemleri...
            return PcanStatus.OK; // Gerçek duruma göre deðiþtir
        }

        public static void GetErrorText(PcanStatus status, out string errorText)
        {
            // Hata metni döndürme iþlemleri...
            errorText = "Dummy error text"; // Gerçek duruma göre deðiþtir
        }
    }

    public enum PcanChannel
    {
        Usb01,
        // Diðer kanallar...
    }

    public enum Bitrate
    {
        Pcan500,
        // Diðer bitrate deðerleri...
    }

    public enum PcanStatus
    {
        OK,
        Error,
        // Diðer durumlar...
    }
}
