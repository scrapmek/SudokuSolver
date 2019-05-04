export default {
    namespaced: true,
    state:{
        data:[
        [1,null,6,null,null,2,3,null,null],
        [null,5,null,null,null,6,null,9,1],
        [null,null,9,5,null,1,4,6,2],
        [null,3,7,9,null,5,null,null,null],
        [5,8,1,null,2,7,9,null,null],
        [null,null,null,4,null,8,1,5,7],
        [null,null,null,2,6,null,5,4,null],
        [null,null,4,1,5,null,6,null,9],
        [9,null,null,8,7,4,2,1,null]
    ]},
    mutations: {
        set(state, payload){
            state.data[payload.row][payload.index] = payload.number;
        }
    }
}