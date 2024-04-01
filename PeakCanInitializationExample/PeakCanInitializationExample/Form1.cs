
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

    // Bu s�n�flar ve enumlar Api, PcanChannel, Bitrate, PcanStatus gibi yap�lar�n tan�mlanmas� gerekecektir.
    // �rne�in:
    public static class Api
    {
        public static PcanStatus Initialize(PcanChannel channel, Bitrate bitrate)
        {
            // Initialize i�lemleri...
            return PcanStatus.OK; // Ger�ek duruma g�re de�i�tir
        }

        public static PcanStatus Uninitialize(PcanChannel channel)
        {
            // Uninitialize i�lemleri...
            return PcanStatus.OK; // Ger�ek duruma g�re de�i�tir
        }

        public static void GetErrorText(PcanStatus status, out string errorText)
        {
            // Hata metni d�nd�rme i�lemleri...
            errorText = "Dummy error text"; // Ger�ek duruma g�re de�i�tir
        }
    }

    public enum PcanChannel
    {
        Usb01,
        // Di�er kanallar...
    }

    public enum Bitrate
    {
        Pcan500,
        // Di�er bitrate de�erleri...
    }

    public enum PcanStatus
    {
        OK,
        Error,
        // Di�er durumlar...
    }
}
