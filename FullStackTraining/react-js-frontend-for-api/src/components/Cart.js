import { createStore } from 'redux';

function todos(state = [], action) {
    switch (action.type) {
        case 'Add':
            return state.concat([action.student]);
        case 'Clear':
            return [];
        default:
            return state
    }
}

const cart = createStore(todos, []);

export default cart;