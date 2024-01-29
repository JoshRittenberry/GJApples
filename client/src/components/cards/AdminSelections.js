import React, { useEffect, useState } from 'react';
import '../stylesheets/adminSelections.css';
import CardItem from './CardItem';
import AdminSelectionItem from './AdminSelectionItem';

export const AdminSelections = () => {
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
            text: 'Create a new user.',
            label: 'New User',
            path: '/'
        },
        {
            id: 2,
            src: '/pictures/orders.jpg',
            alt: 'Garry Jones Picking Apples',
            text: 'View all orders needing to be completed.',
            label: 'Orders',
            path: '/orderpicker'
        },
        {
            id: 3,
            src: '/pictures/harvest.jpg',
            alt: 'Garry Jones Picking Apples',
            text: 'View all trees needing to be harvested.',
            label: 'Harvests',
            path: '/harvester'
        },
        {
            id: 4,
            src: '/pictures/trees.jpg',
            alt: 'Garry Jones Picking Apples',
            text: 'View, and edit, trees currently on the orchard.',
            label: 'Trees',
            path: '/trees'
        },
        {
            id: 5,
            src: '/pictures/apples.jpg',
            alt: 'Garry Jones Picking Apples',
            text: 'View, and edit, apples currently grown on the orchard.',
            label: 'Apples',
            path: '/apples'
        }
    ]

    const renderSelectionList = () => {
        const selectionGroups = [];

        if (screenWidth >= 1600) {
            for (let i = 0; i < selections.length; i += 3) {
                const group = selections.slice(i, i + 3)

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
                )
            }
        }

        if (screenWidth < 1600) {
            for (let i = 0; i < selections.length; i += 1) {
                const group = selections.slice(i, i + 1);

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
        }

        return selectionGroups;
    };

    return (
        <div className='cards__adminselection'>
            {/* <h1>Check out these EPIC Destinations!</h1> */}
            <div className='cards__adminselection__container'>
                <div className='cards__adminselection__wrapper'>
                    {renderSelectionList()}
                </div>
            </div>
        </div>
    );
}

export default AdminSelections;