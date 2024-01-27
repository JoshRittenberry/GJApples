import React from 'react';
import '../stylesheets/cards.css';
import CardItem from '../cards/CardItem';

export const NewOrderSelections = ({ apples }) => {
    console.log(apples)
    return (
        <div className='cards'>
            <div className='cards__container'>
                <div className='cards__wrapper'>
                    <ul className='cards__items'>
                        {apples.map(apple => {
                            return (
                                <CardItem
                                    src={apple.imageUrl}
                                    alt={`${apple.type} Image`}
                                    text={apple.type}
                                    label={`$${apple.costPerPound}`}
                                />
                            )
                        })}
                    </ul>
                </div>
            </div>
        </div>
    );
}

export default NewOrderSelections;