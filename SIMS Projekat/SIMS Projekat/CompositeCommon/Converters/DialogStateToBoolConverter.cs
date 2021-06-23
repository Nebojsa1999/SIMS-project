using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SIMS_Projekat.CompositeCommon.Enums;

namespace SIMS_Projekat.CompositeCommon.Converters
{
    public class DialogStateToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }
            DialogState dialogState;

            try
            {
                dialogState = (DialogState)value;
            }
            catch (Exception)
            {
                return false;
            }
            if (dialogState == DialogState.View || dialogState == DialogState.PickUp)
            {
                return false;
            }

            return true;
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
