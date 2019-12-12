<template>
    <div>

 <Vue2InteractDraggable
  @draggedLeft="draggedLeft"
  :interact-event-bus-events="interactEventBusEvents"
  v-if="isShowing"
  class="card">
  <div>
    <h3 class="cardTitle"><p>results</p>Drag me!</h3>
  </div>
 </Vue2InteractDraggable>

 <BaseButton @click="dragLeft" label="⇦" />

    </div>
</template>

<script>
import { Vue2InteractDraggable, InteractEventBus } from 'vue2-interact'
const INTERACT_DRAGGED_LEFT = 'INTERACT_DRAGGED_LEFT';

export default {
  components: { Vue2InteractDraggable },
  data() {
    return {
      isShowing: true,
      interactEventBusEvents: {
        draggedLeft: INTERACT_DRAGGED_LEFT,
      },
    };
  },

  methods: {
    dragLeft() {
      InteractEventBus.$emit(INTERACT_DRAGGED_LEFT);
    },
  }
};
</script>

<style lang="scss" scoped>
.container {
  background: #eceff1;
  width: 100%;
  height: 100vh;
}

.flex {
  display: flex;
  &--center {
    align-items: center;
    justify-items: center;
    justify-content: center;
  }
}

.fixed {
  position: fixed;
  &--center {
    left: 50%;
    top: 50%;
    transform: translate(-50%, -50%);
  }
}
.rounded-borders {
  border-radius: 12px;
}
.card {
  width: 300px;
  height: 400px;
  color: white;
  &--one {
    background-color: pink;
  }
  &--two {
    background-color: red;
    width: 280px;
    top: 51%;
  }
  &--three {
    background-color: orange;
    width: 260px;
    top: 51.8%;
  }
}
</style>