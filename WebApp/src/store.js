import Vue from 'vue'
import Vuex from 'vuex'
import input from './stores/input'
import output from './stores/output'

Vue.use(Vuex)

export default new Vuex.Store({
  actions: {
    solve(context){
      let input = context.state.input.data;

      fetch(
        'https://localhost:5001/api/values',
        {
          'method':'POST',
          'headers':{
            'Content-type': 'application/json'
          },
          'body': JSON.stringify(input)
        })
      .then(
        function (response){
         return response.json();
        })
      .then(function (data){
          console.log('Request succeeded with JSON response', data);
          context.commit('output/set', data);
        })
      .catch(
        function (error){ 
          console.log('Request failed', error);
        });
    }
  },
  modules:{
    input,
    output
  }
})


