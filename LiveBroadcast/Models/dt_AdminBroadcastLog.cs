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
    
    public partial class dt_AdminBroadcastLog
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public int LiveId { get; set; }
        public System.DateTime SendTime { get; set; }
        public string BroadcastText { get; set; }
        public byte Status { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
    }
}
