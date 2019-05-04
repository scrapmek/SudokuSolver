<template>
    <div>
        <SudokuGrid get="input/data" set="input/set" class="sudokuGrid" />
        <Arrow/>
        <SudokuGrid get="output/data" set="output/set" class="sudokuGrid"/>
    </div>
</template>

<script>
import SudokuGrid from '@/components/Sudoku/SudokuGrid'
import Arrow from '@/components/Arrow.vue'

export default {
    components:{
        SudokuGrid,
        Arrow
    }
}
</script>

<style scoped>
.sudokuGrid{
float: left;
}
</style>
