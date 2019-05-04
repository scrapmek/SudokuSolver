export default {
    namespaced: true,
    state:{
        data:[
            [null, null, null,null, null, null,null, null, null],
            [null, null, null,null, null, null,null, null, null],
            [null, null, null,null, null, null,null, null, null],
            [null, null, null,null, null, null,null, null, null],
            [null, null, null,null, null, null,null, null, null],
            [null, null, null,null, null, null,null, null, null],
            [null, null, null,null, null, null,null, null, null],
            [null, null, null,null, null, null,null, null, null],
            [null, null, null,null, null, null,null, null, null],
        ]
    },
    mutations: {
        set(state, payload){
            state.data = payload;
        }
    }
}