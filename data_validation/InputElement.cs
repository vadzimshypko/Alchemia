namespace DataValidation
{
    public class InputElement
    {
        public string id_name;
        public string display_name;
        public string image;

        public override string ToString()
        {
            return "id_name:" + id_name + ";dispaly_name:" + display_name + ";image:" + image;
        }

    }
}
