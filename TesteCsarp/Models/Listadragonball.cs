namespace TesteCsarp.Models

{

    public class Listadragonball

    {

        public int id  { get; set; }

        public string OfficialName { get; set; }

        public string image { get; set; }

    }


    public class ListadragonballApiResponse

    {

        public int id { get; set; }

        public string OfficialName { get; set; }

        public string image { get; set; }

    }


    public class OfficialName

    {

        public string name { get; set; }

    }

    public class Id

    {

        public string id { get; set; }

    }


    public class Image

    {

        public string image { get; set; }

    }


}