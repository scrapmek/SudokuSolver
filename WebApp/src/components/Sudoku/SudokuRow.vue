<template>
  <div>
    <Cell :get="get" :set="set" :rowIndex="0" :row="row"/>
    <Cell :get="get" :set="set" :rowIndex="1" :row="row"/>
    <Cell :get="get" :set="set" :rowIndex="2" :row="row"/>
    <SudokuVerticalDivider />
    <Cell :get="get" :set="set" :rowIndex="3" :row="row"/>
    <Cell :get="get" :set="set" :rowIndex="4" :row="row"/>
    <Cell :get="get" :set="set" :rowIndex="5" :row="row"/>
    <SudokuVerticalDivider />
    <Cell :get="get" :set="set" :rowIndex="6" :row="row"/>
    <Cell :get="get" :set="set" :rowIndex="7" :row="row"/>
    <Cell :get="get" :set="set" :rowIndex="8" :row="row"/>
  </div>
</template>

<script>
import Cell from './SudokuCell'
import SudokuVerticalDivider from './SudokuVerticalDivider'

export default {
    props:{
        row: Number,
        set: String,
        get: String
    },
    components:{
        Cell,
        SudokuVerticalDivider
    }
}
</script>

<style  scoped>
div{
float:left;  
}
</style>
