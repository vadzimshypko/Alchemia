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

        public bool AreFieldsSet()
        {
            return !(id_name.Equals("") || id_name == null) &&
                !(display_name.Equals("") || display_name == null) &&
                !(image.Equals("") || image == null);

        }

    }
}
