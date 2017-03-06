namespace SoftUniStore.App.ViewModels
{
    public class AdminGamesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Size { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return " <tr>"+
                        $"<td>{this.Title}</td>"+ 
                           $"<td>{this.Size} GB </td>"+     
                              $"<td>{this.Price} & euro;</td>"+          
                                 "<td>"+          
                                     $"<a href=\"/admin/edit?gameId={this.Id}\" class=\"btn btn-warning btn-sm\">Edit</a>"+
                            $" <a href=\"/admin/delete?gameId={this.Id}\" class=\"btn btn-danger btn-sm\">Delete</a>"+
                        "</td>"+
                    "</tr>";
        }
    }
}
