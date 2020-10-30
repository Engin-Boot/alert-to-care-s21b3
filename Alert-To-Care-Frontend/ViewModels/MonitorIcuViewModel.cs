using Alert_To_Care_Frontend.Models;
using Alert_To_Care_Frontend.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Alert_To_Care_Frontend.ViewModel
{
    class MonitorIcuViewModel : BaseViewModel
    {
        #region Intialisers
        public MonitorIcuViewModel()
        {
            GetAllBedsForIcu();
            GetIcuLayout();
        }
        #endregion

        #region Properties
        public ObservableCollection<BedDataModel> BedDataModelList { get; set; } = new ObservableCollection<BedDataModel>();

        public string IcuLayout { get; set; }
        #endregion

        #region Logic

        private void GetIcuLayout()
        {
            string icuId = Properties.Settings.Default.currentIcuId;

            if (icuId != null)
                IcuLayout = HttpClientUtility.GetData("api/IcuData/GetLayout/" + icuId).Result;
        }

        private int GetBedNumFromBedId(string bedId)
        {
            string bedNum = bedId.Replace(Properties.Settings.Default.currentIcuId, "").Replace("Bed", "");
            return int.Parse(bedNum);
        }

        private void GetAllBedsForIcu()
        {
            string icuId = Properties.Settings.Default.currentIcuId;

            if (icuId == null)
                return;

            List<BedDataModel> beds = HttpClientUtility.GetBeds(icuId).Result.ToList();

            beds.Sort((bedOne, bedTwo) => GetBedNumFromBedId(bedOne.BedId).CompareTo(GetBedNumFromBedId(bedTwo.BedId)));

            foreach (BedDataModel bed in beds)
            {
                BedDataModelList.Add(bed);
            }
        }
        #endregion
    }
}
