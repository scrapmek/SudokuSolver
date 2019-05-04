<template>
  <div>
    <Row :row="0" :get="get" :set="set"/>
    <Row :row="1" :get="get" :set="set"/>
    <Row :row="2" :get="get" :set="set"/>
    <Horizontal />
    <Row :row="3" :get="get" :set="set"/>
    <Row :row="4" :get="get" :set="set"/>
    <Row :row="5" :get="get" :set="set"/>
    <Horizontal />
    <Row :row="6" :get="get" :set="set"/>
    <Row :row="7" :get="get" :set="set"/>
    <Row :row="8" :get="get" :set="set"/>
  </div>
</template>

<script>
import Horizontal from './SudokuHorizontalDivider'
import Row from './SudokuRow'

export default {
    props:{
      get: String,
      set: String
    },
    components: {
        Row,
        Horizontal
    }
}
</script>

<style scoped>
div{
  width:452px;
}
</style>
