//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiveBroadcast.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class dt_SensitiveSentences
    {
        public int id { get; set; }
        public string content { get; set; }
        public byte state { get; set; }
        public string remark { get; set; }
        public System.DateTime addtime { get; set; }
        public System.DateTime updatetime { get; set; }
        public int adminid { get; set; }
        public string adminname { get; set; }
        public byte[] lockid { get; set; }
    }
}
