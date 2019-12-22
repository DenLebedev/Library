$(document).ready(function () {

    GetAllBooks();

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

    $("#createBlock").css('display', 'block');
    $("#editBlock").css('display', 'none');
    $("#detailsBlock").css('display', 'none');
    WriteMenu();
    $.ajax({
        url: '/api/library',
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
        Name: $('#editName').val(),
        Author: $('#editAuthor').val(),
        Publishing: $('#editPublishing').val(),
        City: $('#editCity').val(),
        YearPublication: $('#editYearPublication').val(),
        ISBN: $('#editISBN').val(),
        PageCount: $('#editPageCount').val(),
        Notes: $('#editNotes').val()
    };

    $.ajax({
        url: '/api/library/',
        type: 'POST',
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
// Удаление книги
function DeleteBook(id) {

    $.ajax({
        url: '/api/library/' + id,
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
// редактирование книги
function EditBook() {
    var id = $('#editId').val()
    // получаем новые значения для редактируемой книги
    var book = {
        Id: $('#editId').val(),
        Name: $('#editName').val(),
        Author: $('#editAuthor').val(),
        Publishing: $('#editPublishing').val(),
        City: $('#editCity').val(),
        YearPublication: $('#editYearPublication').val(),
        ISBN: $('#editISBN').val(),
        PageCount: $('#editPageCount').val(),
        Notes: $('#editNotes').val()
    };
    $.ajax({
        url: '/api/library/' + id,
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
// вывод полученных данных на экран
function WriteResponse(books) {
    var strResult = "<table class='table table-hover'>";
    $.each(books, function (index, book) {
        strResult += "<tr><td><a class='link' id='detailsItem'data-item='" + book.Id + "' onclick='DetailsItem(this);' > " + book.Author.Name + " " + book.Author.Surname + " - " + book.Name + " " + book.YearPublication + " </a><td><button id='editItem' class='btn btn-outline-primary' data-item='" + book.Id + "' onclick='EditItem(this);' >Edit</button></td><td><button id='delItem' class='btn btn-outline-primary' data-item='" + book.Id + "' onclick='DeleteItem(this);' >Delete</button></td></tr>";
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
        $('#editAuthor').val(book.Author.Surname);
        $('#editPublishing').val(book.Publishing.Name);
        $('#editCity').val(book.City.Name);
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
        url: '/api/library/' + id,
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
        url: '/api/library/' + id,
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
    $("#addAuthor").val("");
    $("#addPublishing").val("");
    $("#addCity").val("");
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
    }
    else {
        alert("There is no such book");
    }
}