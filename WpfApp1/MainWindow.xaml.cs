using DPFP;
using DPFP.Capture;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Security.Credentials.UI;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, DPFP.Capture.EventHandler
    {
        private DPFP.Capture.Capture Capturer;
        private DPFP.Verification.Verification Verificator;
        public MainWindow()
        {
            TemplateDbContext _context = new TemplateDbContext();
            Capturer = new DPFP.Capture.Capture();              
      
            // Create a capture operation.
              // Create a fingerprint template verificator
            if (null != Capturer)
            {
                Capturer.EventHandler = this;
                Capturer.StartCapture();
            }

            var serviceCollection = new ServiceCollection();

            Verificator = new DPFP.Verification.Verification();

            InitializeComponent();
        }

        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            //throw new NotImplementedException();
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            //throw new NotImplementedException();
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
           // throw new NotImplementedException();
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
           // throw new NotImplementedException();
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            //throw new NotImplementedException();
        }


        protected void Process(DPFP.Sample Sample)
        {
            //Process the sample and create a feature set for the enrollment purpose.
            

            //var consentResult = UserConsentVerifier.RequestVerificationAsync("");

            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

            // Check quality of the sample and start verification if it's good
            // TODO: move to a separate task
            if (features != null)
            {
                // Compare the feature set with our template
                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();

                DPFP.Template template = new DPFP.Template();
                Stream stream;


                using (TemplateDbContext _context = new TemplateDbContext())
                {
                    DataTable dataTable = new DataTable();
                    var sqlcomand = new SqlDataAdapter("SELECT TemplateID, TemplateData  FROM [dbo].[Template]", (SqlConnection)_context.Database.Connection);

                    sqlcomand.Fill(dataTable);

                    for (int i = 0; i <= dataTable.Rows.Count; i++)
                    {
                        //byte[] fingerprint = Convert.FromBase64String(dataTable.Rows[i].ItemArray[1]);
                        stream = new MemoryStream((byte[])dataTable.Rows[i].ItemArray[1]);
                        template = new DPFP.Template(stream);

                        Verificator.Verify(features, template, ref result);


                        if (result.Verified)
                        {
                            throw new Exception("Was okey");
                        }
                        else
                        {
                            Console.WriteLine("No Okey");
                        }
                    }
                }

            }

            try
            {
                // Request the logged on user's consent via fingerprint swipe.
                //var consentResult =  UserConsentVerifier.RequestVerificationAsync("");

                //switch (consentResult)
                //{
                //    case serConsentVerificationResult.Verified:
                //        returnMessage = "Fingerprint verified.";
                //        break;
                //    case Windows.Security.Credentials.UI.UserConsentVerificationResult.DeviceBusy:
                //        returnMessage = "Biometric device is busy.";
                //        break;
                //    case Windows.Security.Credentials.UI.UserConsentVerificationResult.DeviceNotPresent:
                //        returnMessage = "No biometric device found.";
                //        break;
                //    case Windows.Security.Credentials.UI.UserConsentVerificationResult.DisabledByPolicy:
                //        returnMessage = "Biometric verification is disabled by policy.";
                //        break;
                //    case Windows.Security.Credentials.UI.UserConsentVerificationResult.NotConfiguredForUser:
                //        returnMessage = "The user has no fingerprints registered. Please add a fingerprint to the " +
                //                        "fingerprint database and try again.";
                //        break;
                //    case Windows.Security.Credentials.UI.UserConsentVerificationResult.RetriesExhausted:
                //        returnMessage = "There have been too many failed attempts. Fingerprint authentication canceled.";
                //        break;
                //    case Windows.Security.Credentials.UI.UserConsentVerificationResult.Canceled:
                //        returnMessage = "Fingerprint authentication canceled.";
                //        break;
                //    default:
                //        returnMessage = "Fingerprint authentication is currently unavailable.";
                //        break;
                //}
            }
            catch (Exception ex)
            {
                //returnMessage = "Fingerprint authentication failed: " + ex.ToString();
            }



        }
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();  // Create a sample convertor.
            Bitmap bitmap = null;                                                           // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);                                 // TODO: return bitmap as a result
            return bitmap;
        }

        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();  // Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);            // TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }
        //public static T CopyTo<T>(this Object myobj, T copyObj)
        //{
        //    Type objectType = myobj.GetType();
        //    Type target = typeof(T);
        //    var x = copyObj;
        //    var d = from source in target.GetMembers().ToList()
        //            where source.MemberType == MemberTypes.Property
        //            select source;
        //    List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
        //       .ToList().Contains(memberInfo.Name)).ToList();
        //    PropertyInfo propertyInfo;
        //    object value;
        //    foreach (var memberInfo in members)
        //    {
        //        propertyInfo = typeof(T).GetProperty(memberInfo.Name);
        //        var prop = myobj.GetType().GetProperty(memberInfo.Name);
        //        if (prop != null && prop.CanWrite)
        //        {
        //            value = prop.GetValue(myobj, null);
        //            if (value != null)
        //            {
        //                propertyInfo.SetValue(x, value, null);
        //            }
        //        }
        //    }
        //    return (T)x;
        //}
    }
}
