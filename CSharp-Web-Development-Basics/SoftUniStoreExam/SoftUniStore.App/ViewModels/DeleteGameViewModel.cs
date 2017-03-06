namespace SoftUniStore.App.ViewModels
{
    public class DeleteGameViewModel
    {
        public int GameId { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            return $"<input type=\"type\" hidden=\"hidden\" name=\"GameId\" value=\"{ this.GameId}\" />"+
                    "<div class=\"form-group row\">"+
                        "<label for=\"name\" class=\"form-control-label\">Title</label>"+
                        "<input type=\"text\" maxlength=\"100\" minlength=\"4\" id=\"name\" class=\"form-control\""+
                               $"placeholder=\"Enter Game Name\" value=\"{this.Title}\" disabled/></div>";
        }
    }
}
