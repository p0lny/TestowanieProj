import './Card.css'

export default function Card ({title, content, image, imageAlt, onCardClick}) {

    return (
        <div className="card mb-3 cardComponent" onClick={onCardClick}>
            <div className="row g-0">
                <div className="col-md-4 overflow-hidden">
                    <img src={image} className="rounded-start col-md-12 cardImage" alt={imageAlt}/>
                </div>
                <div className="col-md-8">
                    <div className="card-body">
                        <h5 className="card-title">{title}</h5>
                        <p className="card-text">{content}</p>
                    </div>
                </div>
            </div>
        </div>
    )
}