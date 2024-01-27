import React from 'react';
import { Link } from 'react-router-dom';

export const NewOrderSelectionItem = (props) => {
    return (
        <>
            <li className='cards__neworderselection__item'>
                <Link className='cards__neworderselection__item__link' to={props.path}>
                    <figure className='cards__neworderselection__item__pic-wrap' data-category={props.label}>
                        <img
                            className='cards__neworderselection__item__img'
                            alt={props.alt}
                            src={props.src}
                        />
                    </figure>
                    <div className='cards__neworderselection__item__info'>
                        <h5 className='cards__neworderselection__item__text'>{props.text}</h5>
                    </div>
                </Link>
            </li>
        </>
    )
}

export default NewOrderSelectionItem;