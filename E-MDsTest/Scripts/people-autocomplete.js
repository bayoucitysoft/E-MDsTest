$(document).ready(function () {
    
    $.ajax({
        url: "/api/people/fullnames",
        success: function (data) {
            var peopleData = new Bloodhound({
                datumTokenizer: Bloodhound.tokenizers.nonword,
                queryTokenizer: Bloodhound.tokenizers.whitespace,
                local: data
            });

            $('#people-search .typeahead').typeahead({
                hint: true,
                highlight: true,
                minLength: 1
            },
            {
                name: 'people',
                source: peopleData
            });
        }
    });

    $('#people-search').bind('typeahead:selected', function (obj, datum, name) {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "/api/people/person?fullName=" + datum,
            success: function (response) {
                var person = response[0];
                $('#firstName').val(person.FirstName);
                $('#lastName').val(person.LastName);
                $('#gender').val(person.Gender);
                $('#dob').val(person.DOB);
            }
        });
    });

    
});