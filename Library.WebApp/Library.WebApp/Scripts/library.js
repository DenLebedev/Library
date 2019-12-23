$(document).ready(function () {

    GetAllBooks();
    GetAllAuthors();
    GetAllPublishings();
    GetAllCities();

    $("#editBook").click(function (event) {
        event.preventDefault();
        EditBook();        
    });

    $("#addBook").click(function (event) {
        event.preventDefault();
        AddBook();
    });

});
// Получение всех книг по ajax-запросу
function GetAllBooks() {
    $("#tableBlock").css('display', 'block');
    $("#createBlock").css('display', 'block');
    $("#editBlock").css('display', 'none');
    $("#detailsBlock").css('display', 'none');    
    WriteMenu();
    $.ajax({
        url: '/api/BookWebApi',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
// Добавление новой книги
function AddBook() {
    // получаем значения для добавляемой книги
    var book = {
        Name: $('#addName').val(),
        Author: {
            Id: $('#addAuthor').val()
        },
        Publishing: {
            Id: $('#addPublishing').val(),
            Name: $('#addPublishing option:selected').text()
        },
        City: {
            Id: $('#addCity').val(),
            Name: $('#addCity option:selected').text()
        },
        YearPublication: $('#addYearPublication').val(),
        ISBN: $('#addISBN').val(),
        PageCount: $('#addPageCount').val(),
        Notes: $('#addNotes').val()
    };

    $.ajax({
        url: '/api/BookWebApi/',
        type: 'POST',
        data: JSON.stringify(book),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllBooks();
            DisplayCreateBlock()
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function DeleteBook(id) {

    $.ajax({
        url: '/api/BookWebApi/' + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllBooks();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function EditBook() {
    var id = $('#editId').val()
    var book = {
        Id: $('#editId').val(),
        Name: $('#editName').val(),
        Author: {
            Id: $('#editAuthor').val()
        },
        Publishing: {
            Id: $('#editPublishing').val()
        },
        City: {
            Id: $('#editCity').val()
        },
        YearPublication: $('#editYearPublication').val(),
        ISBN: $('#editISBN').val(),
        PageCount: $('#editPageCount').val(),
        Notes: $('#editNotes').val()
    };
    $.ajax({
        url: '/api/BookWebApi/' + id,
        type: 'PUT',
        data: JSON.stringify(book),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllBooks();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function WriteResponse(books) {
    var strResult = "<table class='table table-hover'>";
    $.each(books, function (index, book) {
        strResult += "<tr><td><a class='link' id='detailsItem'data-item='" + book.Id + "' onclick='DetailsItem(this);' > " + book.IndexName + " </a></tr>";
    });
    strResult += "</table>";
    $("#tableBlock").html(strResult);
}

function DeleteItem(el) {
    var id = $(el).attr('data-item');
    DeleteBook(id);
}

function EditItem(el) {
    var id = $(el).attr('data-item');
    GetBookEdit(id);
}

function DetailsItem(el) {
    var id = $(el).attr('data-item');
    GetBookDetails(id);
}

function ShowBookEdit(book) {
    if (book != null) {
        $("#createBlock").css('display', 'none');
        $("#editBlock").css('display', 'block');
        $("#editId").val(book.Id);
        $("#editName").val(book.Name);
        $('#editAuthor option[value=' + book.Author.Id + ']').prop('selected', true);
        $('#editPublishing option[value=' + book.Publishing.Id + ']').prop('selected', true);
        $('#editCity option[value=' + book.City.Id + ']').prop('selected', true);
        $('#editYearPublication').val(book.YearPublication);
        $('#editISBN').val(book.ISBN);
        $('#editPageCount').val(book.PageCount);
        $('#editNotes').val(book.Notes);
    }
    else {
        alert("There is no such book");
    }
}

function GetBookEdit(id) {
    $.ajax({
        url: '/api/BookWebApi/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data) {            
            ShowBookEdit(data);            
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function GetBookDetails(id) {
    $.ajax({
        url: '/api/BookWebApi/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            ShowBookDetails(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function WriteMenu() {
    var result = "<button class='btn btn-primary' onclick='DisplayCreateBlock();'>Add new Book</button>"
    $("#menuCreate").html(result);
}

function DisplayCreateBlock() {
    $("#createBlock").css('display', 'block');
    $("#editBlock").css('display', 'none');
    $("#addName").val("");
    $('#addAuthor option').prop('selected', false);
    $('#addPublishing option').prop('selected', false);
    $('#addCity option').prop('selected', false);
    $("#addYearPublication").val("");
    $("#addISBN").val("");
    $("#addPageCount").val("");
    $("#addNotes").val("");
}

function ShowBookDetails(book) {
    if (book != null) {
        $("#detailsBlock").css('display', 'block');
        $("#tableBlock").css('display', 'none');
        $("#detailsId").text(book.Id);
        $("#detailsName").text(book.Name);
        $("#detailsAuthor").text(book.Author.Name + " " + book.Author.Surname);
        $("#detailsPublishing").text(book.Publishing.Name);
        $("#detailsCity").text(book.City.Name);
        $("#detailsYearPublication").text(book.YearPublication);
        $("#detailsISBN").text(book.ISBN);
        $("#detailsPageCount").text(book.PageCount);
        $("#detailsNotes").text(book.Notes);
        $("#detailsBlock").append("<button id='editItem' class='btn btn-outline-primary' data-item='" + book.Id + "' onclick='EditItem(this);' >Edit</button> <button id='delItem' class='btn btn-outline-primary' data-item='" + book.Id + "' onclick='DeleteItem(this);' >Delete</button></td></tr>");
    }
    else {
        alert("There is no such book");
    }
}

function GetAllAuthors() {
    $.ajax({
        url: '/api/AuthorWebApi',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            FillAuthorsSelect(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function FillAuthorsSelect(authors) {
    $.each(authors, function (index, author) {
        $('#addAuthor').append('<option value="' + author.Id + '">' + author.Name + " " + author.Surname + '</option>');
    });
    $.each(authors, function (index, author) {
        $('#editAuthor').append('<option value="' + author.Id + '">' + author.Name + " " + author.Surname + '</option>');
    });
}

function GetAllCities() {
    $.ajax({
        url: '/api/CityWebApi',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            FillCitiesSelect(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function FillCitiesSelect(cities) {
    $.each(cities, function (index, city) {
        $('#addCity').append('<option value="' + city.Id + '">' + city.Name + '</option>');
    });
    $.each(cities, function (index, city) {
        $('#editCity').append('<option value="' + city.Id + '">' + city.Name + '</option>');
    });
}

function GetAllPublishings() {
    $.ajax({
        url: '/api/PublishingWebApi',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            FillPublishingsSelect(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function FillPublishingsSelect(publishings) {
    $.each(publishings, function (index, publishing) {
        $('#addPublishing').append('<option value="' + publishing.Id + '">' + publishing.Name + '</option>');
    });
    $.each(publishings, function (index, publishing) {
        $('#editPublishing').append('<option value="' + publishing.Id + '">' + publishing.Name + '</option>');
    });
}