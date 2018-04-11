public string ProceduceSerialNumber()
{
	//code string; AAAA is a string that customized
	string code = "AAAA" +DateTime.Now.Tostring("yyMMdd");
	//sql for database table 
	string sql = "SELECT column_name FROM table_name WHERE id LIKE '"+code+"%"+"' ORDER BY column_id DESC";
	//the result of search collection assigns to dt
	DataTable dt = this.GetDataTable(sql);
	//jurge id have been proceduce serial number, if not, the serial number begin as 001
	if(dt.Rows.Count == 0) return code + "001";
	string id = dt.Rows[0]["column_id"].ToString().Replace(code,"").Trim();
	code = code + (Convert.ToInt16(id) + 1).ToString().PadLeft(3,'0'); //generate serial number xxx(three-digit number)
	return code;
}
