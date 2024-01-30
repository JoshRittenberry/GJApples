import React, { useEffect, useState } from 'react';
import '../stylesheets/adminEmployeeSelections.css';
import AdminSelectionItem from './AdminSelectionItem';
import { AdminEmployeeSelectionItem } from './AdminEmployeeSelectionItem';

export const AdminEmployeeSelections = () => {

    let selections = [
        {
            id: 1,
            src: '/pictures/employees_edit.jpg',
            alt: 'Garry Jones Picking Apples',
            text: 'View and Edit Employees',
            label: 'Employees',
            path: '/employees/view'
        },
        {
            id: 2,
            src: '/pictures/employees_new.jpg',
            alt: 'Garry Jones Picking Apples',
            text: 'Create a New Employee Account',
            label: 'Orders',
            path: '/employees/new'
        }
    ]

    return (
        <div className='cards__adminemployeeselection'>
            <div className='cards__adminemployeeselection__container'>
                <div className='cards__adminemployeeselection__wrapper'>
                    <ul className='cards__adminemployeeselection__items'>
                        {selections.map((selection) => (
                            <AdminEmployeeSelectionItem
                                src={selection.src}
                                alt={selection.alt}
                                text={selection.text}
                                label={selection.label}
                                path={selection.path}
                            />
                        ))}
                    </ul>
                </div>
            </div>
        </div>
    );
}

export default AdminEmployeeSelections;