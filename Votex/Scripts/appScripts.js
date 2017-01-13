//Jquery UI Date Picker
$(document).ready(function () {
    $(".datePicker").datepicker({
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        yearRange: "-150:+0"
    });
});


// Political Parties Page

$(document)
    .ready(function () {

        $(document)
            .ready(function () {
                var table = $("#politicalParties")
                    .DataTable({
                        ajax: {
                            url: "/politicalParties/GetAllData",
                            dataSrc: ""
                        },
                        columns: [
                            {
                                data: "Name",
                                render: function (data, type, politicalParty) {
                                    return "<a href='/politicalParties/Edit/" + politicalParty.Id + "'>" + politicalParty.Name + "</a>";
                                }
                            },
                            {
                                data: "Id",
                                render: function (data, type, politicalParty) {
                                    return "<a href='/politicalParties/Edit/" + politicalParty.Id + "'>Edit</a>";
                                }
                            },
                            {
                                data: "Id",
                                render: function (data) {
                                    return "<button class='btn-link js-delete' data-party-id=" + data + ">Delete</button>";
                                }
                            }
                        ]
                    });


                $("#politicalParties")
                    .on("click",
                        ".js-delete",
                        function () {
                            var button = $(this);
                            bootbox.confirm("Are you sure that you want to delete this record?",
                                function (result) {
                                    if (result) {
                                        $.ajax({
                                            url: "/politicalparties/Delete/" + button.attr("data-party-id"),
                                            method: "DELETE",
                                            success: function () {
                                                table.row(button.parents("tr")).remove().draw();
                                                toastr.success("Record successfully deleted.");
                                            },
                                            error: function () {
                                                toastr.error("Something went wrong!");
                                            }
                                        });
                                    }
                                });
                        });
            });
    });


// Candidates Page

$(document)
    .ready(function () {
        $(document)
            .ready(function () {
                var candidateTable = $("#Candidates")
                    .DataTable({
                        ajax: {
                            url: "/Candidates/GetAllData",
                            dataSrc: ""
                        },
                        columns: [
                            {
                                data: "FullName",
                                render: function (data, type, candidate) {
                                    return "<a href='/Candidates/Edit/" + candidate.Id + "'>" + candidate.FullName + "</a>";
                                }
                            },
                            {
                                data: "PoliticalParty.Name"
                            },
                            {
                                data: "Id",
                                render: function (data, type, candidate) {
                                    return "<a href='/Candidates/Edit/" + candidate.Id + "'>Edit</a>";
                                }
                            },
                            {
                                data: "Id",
                                render: function (data) {
                                    return "<button class='btn-link js-delete' data-candidate-id=" + data + ">Delete</button>";
                                }
                            }
                        ]
                    });

                $("#Candidates")
                    .on("click",
                        ".js-delete",
                        function () {
                            var button = $(this);
                            bootbox.confirm("Are you sure that you want to delete this record?",
                                function (result) {
                                    if (result) {
                                        $.ajax({
                                            url: "/Candidates/Delete/" + button.attr("data-candidate-id"),
                                            method: "DELETE",
                                            success: function () {
                                                candidateTable.row(button.parents("tr")).remove().draw();
                                                toastr.success("Record successfully deleted.");
                                            },
                                            error: function () {
                                                toastr.error("Something went wrong!");
                                            }
                                        });
                                    }
                                });
                        });
            });
    });


// Electoral Districts

$(document)
    .ready(function () {
        $(document)
            .ready(function () {
                var electoralDistrictsTable = $("#ElectoralDistricts")
                    .DataTable({
                        ajax: {
                            url: "/ElectoralDistricts/GetAllData",
                            dataSrc: ""
                        },
                        columns: [
                            {
                                data: "Name",
                                render: function (data, type, electoralDistrict) {
                                    return "<a href='/ElectoralDistricts/Edit/" + electoralDistrict.Id + "'>" + electoralDistrict.Name + "</a>";
                                }
                            },
                            {
                                data: "Id",
                                render: function (data, type, electoralDistrict) {
                                    return "<a href='/ElectoralDistricts/Edit/" + electoralDistrict.Id + "'>Edit</a>";
                                }
                            },
                            {
                                data: "Id",
                                render: function (data) {
                                    return "<button class='btn-link js-delete' data-ectoraldistrict-id=" + data + ">Delete</button>";
                                }
                            }
                        ]
                    });

                $("#ElectoralDistricts")
                    .on("click",
                        ".js-delete",
                        function () {
                            var button = $(this);
                            bootbox.confirm("Are you sure that you want to delete this record?",
                                function (result) {
                                    if (result) {
                                        $.ajax({
                                            url: "/ElectoralDistricts/Delete/" + button.attr("data-ectoraldistrict-id"),
                                            method: "DELETE",
                                            success: function (response) {
                                                if (response != null) {
                                                    if (response.success) {
                                                        electoralDistrictsTable.row(button.parents("tr"))
                                                            .remove()
                                                            .draw();
                                                        toastr.success("Record successfully deleted.");
                                                    } else {
                                                        toastr.error(response.responseText);
                                                    }
                                                }
                                            },
                                            error: function (xhr, status, error) {
                                                toastr.error("Something went wrong!");
                                            }
                                        });
                                    }
                                });
                        });
            });
    });


// Voters Management

$(document)
    .ready(function () {
        $(document)
            .ready(function () {
                var votersTable = $("#Voters")
                    .DataTable({
                        ajax: {
                            url: "/Voters/GetAllData",
                            dataSrc: ""
                        },
                        columns: [
                            {
                                data: "User.FullName",
                                render: function (data, type, voter) {
                                    return "<a href='/Voters/Edit/" + voter.Id + "'>" + voter.User.FullName + "</a>";
                                }
                            },
                            {
                                data: "RegistrationId"
                            },
                            {
                                data: "ElectoralDistrict.Name"
                            },
                            {
                                data: "Id",
                                render: function (data, type, voter) {
                                    return "<a href='/Voters/Edit/" + voter.Id + "'>Edit</a>";
                                }
                            },
                            {
                                data: "Id",
                                render: function (data) {
                                    return "<button class='btn-link js-delete' data-voter-id=" + data + ">Delete</button>";
                                }
                            }
                        ]
                    });

                $("#Voters")
                    .on("click",
                        ".js-delete",
                        function () {
                            var button = $(this);
                            bootbox.confirm("Are you sure that you want to delete this record?",
                                function (result) {
                                    if (result) {
                                        $.ajax({
                                            url: "/Voters/Delete/" + button.attr("data-voter-id"),
                                            method: "DELETE",
                                            success: function () {
                                                votersTable.row(button.parents("tr")).remove().draw();
                                                toastr.success("Record successfully deleted.");
                                            },
                                            error: function () {
                                                toastr.error("Something went wrong!");
                                            }
                                        });
                                    }
                                });
                        });
            });
    });


// Issues

$(document)
    .ready(function () {
        $(document)
            .ready(function () {
                var issuesTable = $("#Issues")
                    .DataTable({
                        ajax: {
                            url: "/Issues/GetAllData",
                            dataSrc: ""
                        },
                        columns: [
                            {
                                data: "Question",
                                render: function (data, type, issue) {
                                    return "<a href='/Issues/Edit/" + issue.Id + "'>" + issue.Question + "</a>";
                                }
                            },
                            {
                                data: "Id",
                                render: function (data, type, issue) {
                                    return "<a href='/Issues/Edit/" + issue.Id + "'>Edit</a>";
                                }
                            },
                            {
                                data: "Id",
                                render: function (data) {
                                    return "<button class='btn-link js-delete' data-issue-id=" + data + ">Delete</button>";
                                }
                            }
                        ]
                    });

                $("#Issues")
                    .on("click",
                        ".js-delete",
                        function () {
                            var button = $(this);
                            bootbox.confirm("Are you sure that you want to delete this record?",
                                function (result) {
                                    if (result) {
                                        $.ajax({
                                            url: "/Issues/Delete/" + button.attr("data-issue-id"),
                                            method: "DELETE",
                                            success: function () {
                                                issuesTable.row(button.parents("tr")).remove().draw();
                                                toastr.success("Record successfully deleted.");
                                            },
                                            error: function () {
                                                toastr.error("Something went wrong!");
                                            }
                                        });
                                    }
                                });
                        });
            });
    });


// Elections

$(document)
    .ready(function () {
        $(document)
            .ready(function () {
                var electionsTable = $("#Elections")
                    .DataTable({
                        ajax: {
                            url: "/Elections/GetAllData",
                            dataSrc: ""
                        },
                        columns: [
                            {
                                data: "Office",
                                render: function (data, type, election) {
                                    return "<a href='/Elections/Edit/" + election.Id + "'>" + election.Office + "</a>";
                                }
                            },
                            {
                                data: "IsPartisan",
                                render: function (data) {
                                    return (data === true) ? "Yes" : "No";
                                }
                            },
                            {
                                data: "Id",
                                render: function (data, type, election) {
                                    return "<a href='/Elections/Edit/" + election.Id + "'>Edit</a>";
                                }
                            },
                            {
                                data: "Id",
                                render: function (data) {
                                    return "<button class='btn-link js-delete' data-election-id=" + data + ">Delete</button>";
                                }
                            }
                        ]
                    });

                $("#Elections")
                    .on("click",
                        ".js-delete",
                        function () {
                            var button = $(this);
                            bootbox.confirm("Are you sure that you want to delete this record?",
                                function (result) {
                                    if (result) {
                                        $.ajax({
                                            url: "/Elections/Delete/" + button.attr("data-election-id"),
                                            method: "DELETE",
                                            success: function () {
                                                electionsTable.row(button.parents("tr")).remove().draw();
                                                toastr.success("Record successfully deleted.");
                                            },
                                            error: function () {
                                                toastr.error("Something went wrong!");
                                            }
                                        });
                                    }
                                });
                        });
            });
    });


// Ballots

$(document)
    .ready(function () {
        $(document)
            .ready(function () {
                var electionsTable = $("#Ballots")
                    .DataTable({
                        ajax: {
                            url: "/Ballots/GetAllData",
                            dataSrc: ""
                        },
                        columns: [
                            {
                                data: "OpenDate",
                                render: function (data, type, ballot) {
                                    return moment.utc(ballot.OpenDate).format("LL");
                                }
                            },
                            {
                                data: "CloseDate",
                                render: function (data, type, ballot) {
                                    return moment.utc(ballot.CloseDate).format("LL");
                                }
                            },
                            {
                                data: "ElectoralDistrict.Name"
                            },
                            {
                                data: "Approved",
                                render: function (data) {
                                    return (data === true) ? "Yes" : "No";
                                }
                            },
                            {
                                data: "Id",
                                render: function (data, type, ballot) {
                                    return "<a href='/Ballots/Edit/" + ballot.Id + "'>Edit</a>";
                                }
                            },
                            {
                                data: "Id",
                                render: function (data) {
                                    return "<button class='btn-link js-delete' data-ballot-id=" + data + ">Delete</button>";
                                }
                            }
                        ]
                    });

                $("#Ballots")
                    .on("click",
                        ".js-delete",
                        function () {
                            var button = $(this);
                            bootbox.confirm("Are you sure that you want to delete this record?",
                                function (result) {
                                    if (result) {
                                        $.ajax({
                                            url: "/Ballots/Delete/" + button.attr("data-ballot-id"),
                                            method: "DELETE",
                                            success: function () {
                                                electionsTable.row(button.parents("tr")).remove().draw();
                                                toastr.success("Record successfully deleted.");
                                            },
                                            error: function () {
                                                toastr.error("Something went wrong!");
                                            }
                                        });
                                    }
                                });
                        });
            });
    });

$("#removeElections").click(function (event) {
    event.preventDefault();
    var listBox = $("#SelectedElectionIds");
    //$("option:selected", $selectedIds).removeAttr("selected");
    $("option:selected", listBox).remove();
});

$("#removeIssues").click(function (event) {
    event.preventDefault();

    var listBox = $("#SelectedIssueIds");

    $("option:selected", listBox).remove();
});

$(document)
    .ready(function () {

        var elections = new Bloodhound({
            datumTokenizer: Bloodhound.tokenizers.obj.whitespace("office"),
            queryTokenizer: Bloodhound.tokenizers.whitespace,
            remote: {
                url: "/Ballots/GetElectionsByFilter?query=%QUERY",
                wildcard: "%QUERY"
            }
        });

        $("#ElectionsFilter")
            .typeahead({
                minLength: 3,
                highlight: true
            },
                {
                    name: "elections",
                    display: "Office",
                    source: elections
                })
            .on("typeahead:select",
                function (e, election) {
                    $("#SelectedElectionIds")
                         .append($("<option></option>")
                                    .attr("value", election.Id)
                                    .text(election.Office)
                                    .attr("selected", "selected")
                                    );
                    $("#ElectionsFilter").typeahead("val", "");
                });


        var issues = new Bloodhound({
            datumTokenizer: Bloodhound.tokenizers.obj.whitespace("question"),
            queryTokenizer: Bloodhound.tokenizers.whitespace,
            remote: {
                url: "/Ballots/GetIssuesByFilter?query=%QUERY",
                wildcard: "%QUERY"
            }
        });

        $("#IssuesFilter")
            .typeahead({
                minLength: 3,
                highlight: true
            },
                {
                    name: "issues",
                    display: "Question",
                    source: issues
                })
            .on("typeahead:select",
                function (e, issue) {
                    $("#SelectedIssueIds")
                         .append($("<option></option>")
                                    .attr("value", issue.Id)
                                    .text(issue.Question)
                                    .attr("selected", "selected")
                                    );
                    $("#IssuesFilter").typeahead("val", "");
                });
    });

//function filterListBox() {
//    var filterText = $("#ElectionsFilter");
//    var listBox = $("#SelectedElectionIds");

//    var filteredKeys = new Array;
//    var filteredValues = new Array;

//    $("#SelectedElectionIds option").each(function () {
//        if ($(this).text().toLowerCase().indexOf(filterText.val()) !== -1) {
//            filteredKeys.push($(this).val());
//            filteredValues.push($(this).text());
//        }
//    });

//    listBox[0].options[0].text.selected = true;

//    //alert(filteredKeys.join(','));
//    //alert(filteredValues.join(','));
//}