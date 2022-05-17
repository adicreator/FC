class ExitPoll extends React.Component {
    render() {
        return React.createElement(
            'div',
            { className: 'exitPoll' },
            'Exit Poll',
        );
    }
}


ReactDOM.render(
    React.createElement(ExitPoll, null),
    document.getElementById('ExitPoll'),
);