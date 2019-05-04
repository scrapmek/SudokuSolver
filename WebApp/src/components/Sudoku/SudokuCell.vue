<template>
    <input type="text" v-model="value" />
</template>

<script>
import { getStatePropertyFromString } from '@/helpers.js'

export default {
    props:{
        get: String,
        set: String,
        rowIndex: Number,
        row: Number
    },
    computed:{
        value:{
            get(){
                return getStatePropertyFromString(this.$store.state, this.get + '/' + this.row + '/' + this.rowIndex);
            },
            set(value){
                this.$store.commit(
                    this.set, 
                    {
                        'number': value,
                        'index': this.rowIndex,
                        'row': this.row
                    });
            }
        }
    }
}
</script>

<style scoped>
input {
    width:46px;
    height:46px;
    text-align: center;
    font-family: Arial, Helvetica, sans-serif;
    font-size: 40px;
    float: left;
    padding:0px;
}
</style>
