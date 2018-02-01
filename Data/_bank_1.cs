namespace Load_bank_files.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class _bank_1
    {
        [Key]
        public int id { get; set; }
        public string filename { get; set; }
	    public string TRAN_ID { get; set; }
        public string БАНК { get; set; }
        public string ОТДЕЛЕНИЕ { get; set; }
        public string ТОЧКА { get; set; }
        public string НАЗВАНИЕ { get; set; }
        public string ТЕРМИНАЛ { get; set; }
        public string ДАТА_ТРАН { get; set; }
        public string ДАТА_РАСЧ { get; set; }
        public float СУММА_ТРАН { get; set; }
        public float СУММА_РАСЧ { get; set; }   
        public string КАРТА { get; set; }
        public string КОД_АВТ { get; set; }
        public string ТИП { get; set; }
    }
}