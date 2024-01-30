import React, { useEffect, useState } from 'react';
import '../stylesheets/adminEmployeeSelections.css';
import AdminSelectionItem from './AdminSelectionItem';
import { AdminEmployeeSelectionItem } from './AdminEmployeeSelectionItem';

export const AdminEmployeeSelections = () => {
    const [screenWidth, setScreenWidth] = useState(window.innerWidth)

    useEffect(() => {
        // Function to update screenWidth state when the window is resized
        const handleResize = () => {
            setScreenWidth(window.innerWidth);
        };

        // Attach the event listener for window resize
        window.addEventListener('resize', handleResize);

        // Clean up the event listener when the component unmounts
        return () => {
            window.removeEventListener('resize', handleResize);
        };
    }, []); // Empty dependency array means this effect runs once after initial render

    let selections = [
        {
            id: 1,
            src: '/pictures/employees.jpg',
            alt: 'Garry Jones Picking Apples',
            text: 'View and Edit Employees',
            label: 'Employees',
            path: '/employees'
        },
        {
            id: 2,
            src: '/pictures/orders.jpg',
            alt: 'Garry Jones Picking Apples',
            text: 'View all open orders',
            label: 'Orders',
            path: '/orders/open'
        }
    ]

    return (
        <div className='cards__adminemployeeselection'>
            <div className='cards__adminemployeeselection__container'>
                <div className='cards__adminemployeeselection__wrapper'>
                    <ul className='cards__adminemployeeselection__items'>
                        {selections.map((selection) => (
                            <AdminSelectionItem
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