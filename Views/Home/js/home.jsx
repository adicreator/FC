class CommentBox extends React.Component {
    render() {
        return React.createElement(
            'div',
            { className: 'commentBox' },
            'Juriku1',
        );
    }
}

ReactDOM.render(
    React.createElement(CommentBox, null),
    document.getElementById('content'),
);