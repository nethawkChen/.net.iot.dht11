namespace Model {
    public class ResponseData<T> {
        /// <summary>
        /// Api 回傳代碼(200為正常)
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Api 回傳訊息(如果是成功 success)
        /// </summary>
        public string? Message { get; set; }
        /// <summary>
        /// Api 執行時間
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Api 回傳的資料
        /// </summary>
        public T? Data { get; set; }
    }
}