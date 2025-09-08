import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";

const Users = () => {
    const columns = [
        {
            title: 'Carnet de identidad',
            dataIndex: 'CI',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.CI.localeCompare(b.CI)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el carnet de identidad",
                },
                {
                    whitespace: true,
                    message: "Introduzca el carnet de identidad"
                }
            ],
        },
        {
            title: 'Nombre',
            dataIndex: 'name',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.name.localeCompare(b.name)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el nombre",
                },
                {
                    whitespace: true,
                    message: "Introduzca el nombre"
                }
            ],
        },
        {
            title: 'Apellidos',
            dataIndex: 'lastName',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.lastName.localeCompare(b.lastName)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca los apellidos",
                },
                {
                    whitespace: true,
                    message: "Introduzca los apellidos",
                }
            ],
        },
        {
            title: 'Correo electrónico',
            dataIndex: 'email',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.email.localeCompare(b.email)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el correo electrónico",
                }
            ]
        }
    ];

    const TableID = 'usersTable';
    const SearchboxID = 'usersSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table title={"Usuarios"}
                        columns={columns}
                        operations={["edit","delete","add","details"]}
                        url={"http://localhost:5145/api/CourseGroups"}
                        tableID={TableID}
                        searchboxID={SearchboxID}
                        link={"../WorkerDetails"}
            thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
                    ></CRUD_Table>
        </div>
    );
};

export default Users;