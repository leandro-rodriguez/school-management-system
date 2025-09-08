import 'react-app-polyfill/ie11';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import {add, format} from 'date-fns';
import NavBar from "../components/NavBar/NavBar";
import {WeeklyCalendar,} from 'antd-weekly-calendar';
import {Button, Card, DatePicker, Form, Input, Modal, Popconfirm, Space, Typography} from 'antd';
import moment from "moment";
import * as PropTypes from "prop-types";
import {CloseSquareTwoTone, DeleteTwoTone, ExclamationCircleTwoTone, SaveTwoTone} from "@ant-design/icons";
import FormItem from "antd/es/form/FormItem";
import axios from "axios";
import {useContext, useEffect, useRef, createContext, useState} from 'react';
import Dropdown from '../components/Dropdown/Dropdown';

import { render } from 'react-dom';


//Date Range Picker
const {RangePicker} = DatePicker;

RangePicker.propTypes = {
    onChange: PropTypes.func,
    showTime: PropTypes.shape({format: PropTypes.string}),
    format: PropTypes.string,
    onOk: PropTypes.any
};

var date = new Date("2016-01-04 23:34");

var formattedDate = format(date, "d/M/yyyy HH:mm:ss a");

console.log(formattedDate);

const Schedules = () => {
    //Modals visibility
    const [isEventModalVisible, setIsEventModalVisible] = useState(false);
    const [isAddModalVisible, setIsAddModalVisible] = useState(false);

    //Fields to add
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [startDate, setStartDate] = useState('');
    const [endDate, setEndDate] = useState('');

    //dropdown
    const [classrooms, setClassrooms] = useState([]);

    const [classroomSelected, setClassroomSelected] = useState();

    //initial events
    const events = [
        {
            eventId: '1',
            description: "Profesor: Rodrigo Segura",
            startTime: new Date("2022-06-27 10:34"),
            endTime: new Date("2022-06-27 18:34"),
            title: 'Francés',
        },
        {
            eventId: '2',
            description: "Profesor: Marta Suárez",
            startTime: new Date("2022-06-28 18:34"),
            endTime: new Date("2022-06-28 20:30"),
            title: 'Álgebra Lineal I',
            backgroundColor: 'green',
        },
        {
            eventId: '3',
            description: "Profesor: Carlos Sanabria",
            startTime: new Date("2022-06-30 08:00"),
            endTime: new Date("2022-06-30 11:00"),
            title: 'Tránsito 101',
            backgroundColor: 'pink',
        }
    ];

    //initial data
    const [data, setData] = useState(events);

    //current event
    const [currentEvent, setCurrentEvent] = useState(events[0]);

    const getData = async () =>
        await axios.get('http://localhost:5145/api/Classrooms')
            .then(resp=>{
                setClassrooms(resp.data);
            });

    useEffect(()=>{
        getData();
    },[]);

    //Operations
    //create
    const createEvent = () => {
        setIsAddModalVisible(false);
        const id = data.length;
        const newData = [{eventId:id, title: title, description: description, startTime: startDate, endTime: endDate}];
        console.log(newData);
        setData([...events, newData]);
    };

    //read
    const EventDetails = () => {
        setIsEventModalVisible(true);
    };

    //update
    const updateEvent = () => {

    };

    //delete
    const deleteEvent = () => {
        const newData = data.filter((item) => item.eventId !== currentEvent.eventId);
        setData(newData);
        setIsEventModalVisible(false);
    };

    const handleChangeDebut = (range) => {
        setStartDate(new Date(range[0].format("d/M/yyyy hh:mm:ss A")).toString());
        setEndDate(new Date(range[1].format("d/M/yyyy hh:mm:ss A")).toString());
    }

    return (
        <div>
            <NavBar></NavBar>

            <Card>
                <div style={{marginBottom: "10px"}}>

                <Dropdown
                    title={"Aula"}
                    options={classrooms}
                    onChange={setClassroomSelected}
                    print={(classroom) => (classroom.name)}
                />

                <Button style={{marginLeft: "10px"}} onClick={() => setIsAddModalVisible(true)}>
                    Añadir turno
                </Button>
                </div>

                <WeeklyCalendar
                    events={data}
                    weekends={true}
                    onEventClick={event => {
                        setCurrentEvent(event);
                        EventDetails();
                        console.log('current', currentEvent)
                    }}
                />{' '}
            </Card>

            <Modal
                title={"Añadir turno"}
                visible={isAddModalVisible}
                centered={true}
                onCancel={() => setIsAddModalVisible(false)}
                footer={null}
            >
                <Form name="scheduleForm" autoComplete={"off"}
                      labelCol={{
                          span: 4,
                      }}
                      wrapperCol={{
                          span: 14,
                      }}>

                    <FormItem name={"Título"} label={"Título"}
                              rules={[
                                  {
                                      required: true,
                                      message: "Introduzca el título"
                                  }
                              ]}
                              hasFeedback={true}>

                        <Input
                            onChange={(e) => {setTitle(e.target.value);}}
                            placeholder={"Título"}>
                        </Input>
                    </FormItem>

                    <FormItem name={"Descripción"} label={"Descripción"}><Input.TextArea
                        onChange={(e) => {setDescription(e.target.value);}}
                        placeholder={"Descripción"}></Input.TextArea></FormItem>

                    <FormItem name={"Horario"} label={"Horario"}>
                        <Space direction="vertical" size={10}>
                            <RangePicker
                                style={{marginBottom: "13px"}}
                                visible={false}
                                showTime={{
                                    format: 'hh:mm:ss A',
                                }}
                                format="d/M/yyyy hh:mm:ss A"
                                onChange={handleChangeDebut}
                                //onOk={onOk}
                            />
                        </Space>
                    </FormItem>
                </Form>
                <div style={{marginLeft: "17%"}}>
                    <Button type="primary"
                            onClick={() => {setIsAddModalVisible(false);
                                console.log(title, description, startDate, endDate);}}
                            htmlType="submit"
                            style={{marginRight: "5px"}}
                    >Guardar</Button>
                    <Button onClick={() => {
                        setIsAddModalVisible(false);
                    }}>Cancelar</Button>
                </div>
            </Modal>

            <Modal
                title={currentEvent.title}
                visible={isEventModalVisible}
                centered={true}
                cancelText={"Cancelar"}
                onCancel={() => setIsEventModalVisible(false)}
                okText={"Aceptar"}
                onOk={() => setIsEventModalVisible(false)}
            >
                <Form>
                    <FormItem>
                    <Input.TextArea
                        defaultValue={currentEvent.description}>
                    </Input.TextArea>
                </FormItem>
                    <FormItem>
                    <Space direction="vertical" size={10}>
                        <RangePicker
                            style={{marginBottom: "13px"}}
                            visible={false}
                            showTime={{
                                format: 'hh:mm:ss A',
                            }}
                            format="d/M/yyyy hh:mm:ss A"
                            defaultValue={[
                                moment(currentEvent.startTime.toString()),
                                moment(currentEvent.endTime.toString())]}
                            //onChange={onChange}
                            //onOk={onOk}
                        />
                    </Space>
                    </FormItem>
                </Form>
                <Popconfirm title="¿Está seguro de que quiere eliminar este evento?" cancelText={"Cancelar"}
                            okText={"Aceptar"} onConfirm={() => deleteEvent()}
                            icon={<ExclamationCircleTwoTone twoToneColor="#eb2f96"/>}>
                    <DeleteTwoTone style={{fontSize:"20px", marginTop:"10px"}}/>
                </Popconfirm>
            </Modal>
        </div>
    );
};

export default Schedules;