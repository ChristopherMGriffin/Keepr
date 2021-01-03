<template>
  <div class="home flex-grow-1 container-fluid justify-content-center">
    <div class="row justify-content-center">
      <h1>Masonry - horizontalOrder</h1>
    </div>

    <div v-masonry="containerId" transition-duration="0.3s" item-selector=".keep">
      <div v-masonry-tile class="keep" v-for="k in keeps" :kprops="k" :key="k.id">
        <!-- block item markup -->
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Home'
}

</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
}

* { box-sizing: border-box; }

body { font-family: sans-serif; }

/* ---- grid ---- */

.grid {
  background: #EEE;
  max-width: 1200px;
  counter-reset: grid-item;
}

/* clearfix */
.grid:after {
  content: '';
  display: block;
  clear: both;
}

/* ---- grid-item ---- */

.grid-item {
  width: 160px;
  height: 120px;
  float: left;
  background: #D26;
  border: 2px solid #333;
  border-color: hsla(0, 0%, 0%, 0.5);
  border-radius: 5px;
}

.grid-item--width2 { width: 320px; }
.grid-item--width3 { width: 480px; }
.grid-item--width4 { width: 720px; }

.grid-item--height2 { height: 200px; }
.grid-item--height3 { height: 260px; }
.grid-item--height4 { height: 360px; }

.grid-item:before {
  counter-increment: grid-item;
  content: counter(grid-item);
  display: block;
  color: white;
  padding-top: 0.2em;
  text-align: center;
  font-size: 1.4rem;
}
</style>
