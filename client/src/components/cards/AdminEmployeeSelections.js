import React, { useEffect, useState } from 'react';
import '../stylesheets/adminEmployeeSelections.css';
import AdminSelectionItem from './AdminSelectionItem';
import { AdminEmployeeSelectionItem } from './AdminEmployeeSelectionItem';

export const AdminEmployeeSelections = () => {

    let selections = [
        {
            id: 1,
            src: '/pictures/employees_edit.jpg',
            alt: 'View Employees',
            text: 'View and Edit Employees',
            label: 'Employees',
            path: '/employees/view'
        },
        {
            id: 2,
            src: '/pictures/employees_new.jpg',
            alt: 'Create Employees',
            text: 'Create a New Employee Account',
            label: 'New Employee',
            path: '/employees/new'
        },
        {
            id: 3,
            src: '/pictures/customer.jpg',
            alt: 'View Customers',
            text: 'View and Edit Customers',
            label: 'Customers',
            path: '/employees/new'
        },
        {
            id: 4,
            src: '/pictures/customer_service.jpg',
            alt: 'Create Customer',
            text: 'Create a New Customer Account',
            label: 'New Customer',
            path: '/employees/new'
        }
    ]

    const renderSelectionList = () => {
        const selectionGroups = [];

        for (let i = 0; i < selections.length; i += 2) {
            const group = selections.slice(i, i + 2);

            selectionGroups.push(
                <ul className='cards__adminselection__items' key={i}>
                    {group.map((selection, index) => (
                        <AdminSelectionItem
                            src={selection.src}
                            alt={selection.alt}
                            text={selection.text}
                            label={selection.label}
                            path={selection.path}
                        />
                    ))}
                </ul>
            );
        }

        return selectionGroups;
    };

    return (
        <div className='cards__adminemployeeselection'>
            <div className='cards__adminemployeeselection__container'>
                <div className='cards__adminemployeeselection__wrapper'>
                    {renderSelectionList()}
                </div>
            </div>
        </div>
    );
}

export default AdminEmployeeSelections;