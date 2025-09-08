import React, {Component} from "react";
import './Menu.css';
import Personal from "../Menu/images/Personal.jpg";
import Offers from "../Menu/images/Offers.jpg";
import Finances from "../Menu/images/Finances.jpg";
import Administration from "../Menu/images/Administration.jpg";
import { useState } from "react";
import axios from "axios";
import jwt_decode from "jwt-decode";
import { useEffect } from "react";

const Menu = () =>  {

    const [isSecretary, setIsSecretary] = useState(false);

    useEffect(()=>{
        if (localStorage['token'] == null)
            return false;

        var decoded = jwt_decode(localStorage['token']);
            
        const roles = decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

        for (let i = 0; i < roles.length; i++) {
            console.log(roles[i]);

            if (roles[i] === 'Secretary')
                setIsSecretary(true);
        }
    },[]);

    console.log(isSecretary);

    if (isSecretary)
        return (
            <div className="menu_container">
                <div className="dropdown" align="left">
                    <button className={"menu_button"}>
                        <img className={"menu_img"} src={Personal} alt="Personal"/>
                    </button>

                    <div className="dropdown-content">
                        <a href="../Students">Estudiantes</a>
                    </div>
                </div>

                <div className="dropdown" align="left">
                    <button className={"menu_button"}>
                        <img className={"menu_img"} src={Offers} alt="Ofertas"/>
                    </button>

                    <div className="dropdown-content">
                        <button className={"menu_button"} data-toggle="dropdown">Cursos</button>
                        <div
                            className="dropdown-sec">
                            <a href="../Courses">Información</a>
                            <a href="../Schedules">Horarios</a>
                        </div>
                    </div>
                </div>
            </div>
        );


    return (
        <div className="menu_container">
            <div className="dropdown" align="left">
                <button className={"menu_button"}>
                    <img className={"menu_img"} src={Personal} alt="Personal"/>
                </button>

                <div className="dropdown-content">
                    <a href="../Students">Estudiantes</a>
                    {!isSecretary && <a href="../Workers">Trabajadores</a>}
                </div>
            </div>

            <div className="dropdown" align="left">
                <button className={"menu_button"}>
                    <img className={"menu_img"} src={Offers} alt="Ofertas"/>
                </button>

                <div className="dropdown-content">
                    <button className={"menu_button"} data-toggle="dropdown">Cursos</button>
                    <div
                        className="dropdown-sec">
                        <a href="../Courses">Información</a>
                        <a href="../Schedules">Horarios</a>
                    </div>
                </div>
            </div>

            <div className="dropdown" align="left">
                <button className={"menu_button"}>
                    <img className={"menu_img"} src={Finances} alt="Finanzas"/>
                </button>

                <div className="dropdown-content">
                    <button className={"menu_button"}>
                        <a href="../Income">Ingresos</a>
                    </button>
                    <div className="dropdown-sec">
                        <a href="../CoursesPayment">Efectuar Cobro de Cursos</a>
                    </div>
                    <a href="../SalaryPayment">Efectuar Pago de Salarios</a>
                    <a href="../Expenses">Gastos</a>
                    <a href="../Debtors">Deudores</a>
                </div>
            </div>

            <div className="dropdown" align="left">
                <button className={"menu_button"}>
                    <img className={"menu_img"} src={Administration} alt="Administración"/>
                </button>

                <div className="dropdown-content">
                    <a href="../Users">Usuarios</a>
                    <a href="../Positions">Cargos</a>
                    <a href="../BasicMean">Medios Básicos</a>
                    <a href="../Classrooms">Aulas</a>
                </div>
            </div>
        </div>
    );
}

export default Menu;

// {!isSecretary &&
            
// }