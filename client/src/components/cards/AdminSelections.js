import React from 'react';
import '../stylesheets/adminSelections.css';
import CardItem from './CardItem';
import AdminSelectionItem from './AdminSelectionItem';

export const AdminSelections = () => {
    return (
        <div className='cards__adminselection'>
            <h1>Check out these EPIC Destinations!</h1>
            <div className='cards__adminselection__container'>
                <div className='cards__adminselection__wrapper'>
                    <ul className='cards__adminselection__items'>
                        <AdminSelectionItem
                            src='/pictures/GJ-Picking-Apples.jpg'
                            alt='Garry Jones Picking Apples'
                            text='Hear from Garry Jones on the humble beginnings of his wonderful apple orchard.'
                            label='History'
                            path='/history'
                        />
                    </ul>
                </div>
            </div>
        </div>
    );
}

export default AdminSelections;